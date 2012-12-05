using System.Collections.Generic;
using ProjectBilling.DataAccess.Entities;

namespace ProjectBilling.SL.ViewModels
{
    public interface IProjectsViewModel
    {
        /// <summary>
        /// Represents the current selected project
        /// </summary>
        IProjectViewModel SelectedProject { get; set; }
    }
}
