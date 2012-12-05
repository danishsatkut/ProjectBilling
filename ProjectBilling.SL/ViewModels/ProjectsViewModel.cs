using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectBilling.DataAccess.Entities;
using ProjectBilling.MVVM.SL.Helpers;
using ProjectBilling.SL.Models;

namespace ProjectBilling.SL.ViewModels
{
    public class ProjectsViewModel : ViewModelBase, IProjectsViewModel
    {
        private const int NONE_SELECTED = 0;
        private readonly IProjectsModel _model = null;

        private ObservableCollection<IProject> _projects;
        private int? _selectedValue;
        private IProjectViewModel _selectedProject;
        private DelegateCommand _updateCommand;
        private bool _detailsEnabled;
        private Status _detailsEstimateStatus;

        public const string ProjectsProperty = "Projects";
        public const string DetailsEnabledProperty = "DetailsEnabled";
        public const string SelectedValueProperty = "SelectedValue";
        public const string SelectedProjectProperty = "SelectedProject";
        public const string DetailsEstimateStatusProperty = "DetailsEstimateStatus";
        public const string UpdateCommandProperty = "UpdateCommand";

        public ProjectsViewModel()
        {
            _model = new ProjectsModel();
            Projects = _model.Projects;
        }

        #region Implementation of IProjectsViewModel

        public ObservableCollection<IProject> Projects
        {
            get { return _projects; }
            set
            {
                _projects = value;
                RaisePropertyChanged(ProjectsProperty);
            }
        }

        #endregion

        public bool DetailsEnabled
        {
            get { return _detailsEnabled; }
            set
            {
                _detailsEnabled = value;
                RaisePropertyChanged(DetailsEnabledProperty);
            }
        }

        public int? SelectedValue
        {
            set
            {
                if (value == null) return;

                IProject project = GetProject((int) value);

                if (SelectedProject == null)
                {
                    SelectedProject = new ProjectViewModel(project);
                }
                else
                {
                    SelectedProject.Update(project);
                }

                DetailsEstimateStatus = SelectedProject.EstimateStatus;
            }
        }

        public IProjectViewModel SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                if (value == null)
                {
                    _selectedProject = null;
                    DetailsEnabled = false;
                } else
                {
                    if (_selectedProject == null)
                    {
                        _selectedProject = new ProjectViewModel(value);
                    }
                    _selectedProject.Update(value);
                    DetailsEstimateStatus = _selectedProject.EstimateStatus;
                    DetailsEnabled = true;
                    RaisePropertyChanged(SelectedProjectProperty);
                }
            }
        }

        public Status DetailsEstimateStatus
        {
            get { return _detailsEstimateStatus; }
            set
            {
                _detailsEstimateStatus = value;
                RaisePropertyChanged(DetailsEstimateStatusProperty);
            }
        }

        public DelegateCommand UpdateCommand
        {
            get { return _updateCommand ?? (_updateCommand = new DelegateCommand(o => UpdateProject())); }
        }

        #region Helper Methods

        private void UpdateProject()
        {
            _model.UpdateProject(SelectedProject);
        }

        private IProject GetProject(int index)
        {
            return Projects.FirstOrDefault(p => p.Id == index + 1);
        }

        #endregion
    }
}