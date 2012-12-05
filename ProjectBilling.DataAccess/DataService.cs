using System.Collections.Generic;
using ProjectBilling.DataAccess.Entities;

namespace ProjectBilling.DataAccess
{
    public class DataService
    {
        public List<Project> GetProjects()
        {
            var projects = new List<Project>
                               {
                                   new Project { Id = 1, Name = "North Wind", Estimated = 10.00m},
                                   new Project { Id = 1, Name = "Adventure Works", Estimated = 12m},
                                   new Project { Id = 1, Name = "Basecamp", Estimated = 6.26m}
                               };
            return projects;
        }
    }
}
