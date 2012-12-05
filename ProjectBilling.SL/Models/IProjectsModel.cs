using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ProjectBilling.DataAccess.Entities;

namespace ProjectBilling.SL.Models
{
    public interface IProjectsModel
    {
        ObservableCollection<IProject> Projects { get; set; }

        void UpdateProject(IProject updatedProject);

        event EventHandler<ProjectUpdatedEventArgs> ProjectUpdated;
    }
}
