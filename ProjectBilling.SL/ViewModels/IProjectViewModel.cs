using ProjectBilling.DataAccess.Entities;

namespace ProjectBilling.SL.ViewModels
{
    public interface IProjectViewModel : IProject
    {
        Status EstimateStatus { get; set; }
        void Update(IProject project);
    }
}