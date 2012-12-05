using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using ProjectBilling.Web.Entities;

namespace ProjectBilling.Web
{
    [ServiceContract(Namespace = "")]
    [SilverlightFaultBehavior]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ProjectsService
    {
        [OperationContract]
        public List<IProject> GetProjects()
        {
            var projects = new List<IProject>
                               {
                                   new Project { Id = 1, Name = "North Wind", Estimated = 10.00m},
                                   new Project { Id = 1, Name = "Adventure Works", Estimated = 12m},
                                   new Project { Id = 1, Name = "Basecamp", Estimated = 6.26m}
                               };
            return projects;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
