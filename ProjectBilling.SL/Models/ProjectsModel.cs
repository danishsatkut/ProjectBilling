using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ProjectBilling.DataAccess;
using ProjectBilling.DataAccess.Entities;

namespace ProjectBilling.SL.Models
{
    public class ProjectsModel : IProjectsModel
    {
        public ProjectsModel()
        {
            var client = new DataService();

            // Parse and add a project in the ObservableCollection
            var projects = client.GetProjects();
            foreach (var project in projects)
            {
                Projects.Add(project);
            }
        }

        #region Implementation of IProjectsModel

        public ObservableCollection<IProject> Projects { get; set; }

        public void UpdateProject(IProject updatedProject)
        {
            var currentProject = GetProject(updatedProject.Id);
            currentProject.Update(updatedProject);
            RaiseProjectUpdated(updatedProject);
        }

        public event EventHandler<ProjectUpdatedEventArgs> ProjectUpdated = delegate { };

        #endregion

        private void RaiseProjectUpdated(IProject project)
        {
            ProjectUpdated(this, new ProjectUpdatedEventArgs(project));
        }

        private IProject GetProject(int projectId)
        {
            return Projects.FirstOrDefault(p => p.Id == projectId);
        }
    }

    /// <summary>
    /// Represents the event arguments for project updated event.
    /// </summary>
    public class ProjectUpdatedEventArgs : EventArgs
    {
        public IProject Project { get; private set; }

        public ProjectUpdatedEventArgs(IProject project)
        {
            Project = project;
        }
    }
}