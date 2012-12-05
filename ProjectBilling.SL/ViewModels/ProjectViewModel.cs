using ProjectBilling.DataAccess.Entities;
using ProjectBilling.SL.Models;

namespace ProjectBilling.SL.ViewModels
{
    public class ProjectViewModel : ViewModelBase, IProjectViewModel
    {
        private Status _estimateStatus = Status.None;
        private decimal _actual;
        private decimal _estimated;
        private int _id;
        private string _name;

        public const string EstimateStatusProperty = "EstimateStatus";
        public const string ActualProperty = "Actual";
        public const string EstimatedProperty = "Estimated";
        public const string IdProperty = "Id";
        public const string NameProperty = "Name";

        // For Blendability
        public ProjectViewModel()
        { }

        public ProjectViewModel(IProject project)
        {
            if (project == null)
                return;

            Id = project.Id;
            Update(project);
        }

        public void Update(IProject project)
        {
            Id = project.Id;
            Name = project.Name;
            Actual = project.Actual;
            Estimated = project.Estimated;
        }

        private void UpdateEstimateStatus()
        {
            if (Actual == 0)
                EstimateStatus = Status.None;
            else if (Actual <= Estimated)
                EstimateStatus = Status.Good;
            else
                EstimateStatus = Status.Bad;
        }

        #region Implementation of IProjectViewModel

        public Status EstimateStatus
        {
            get { return _estimateStatus; }
            set
            {
                _estimateStatus = value;
                RaisePropertyChanged(EstimateStatusProperty);
            }
        }

        #endregion

        #region Implementation of IProjects

        public decimal Actual
        {
            get { return _actual; }
            set
            {
                if (_actual != value)
                {
                    _actual = value;
                    UpdateEstimateStatus();
                    RaisePropertyChanged(ActualProperty);
                }
            }
        }

        public decimal Estimated
        {
            get { return _estimated; }
            set
            {
                if (_estimated != value)
                {
                    _estimated = value;
                    RaisePropertyChanged(EstimatedProperty);
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged(NameProperty);
            }
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged(IdProperty);
                }
            }
        }

        #endregion
    }
}