namespace ProjectBilling.DataAccess.Entities
{
    public class Project : IProject
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public decimal Actual { get; set; }

        public decimal Estimated { get; set; }

        public void Update(IProject project)
        {
            Name = project.Name;
            Actual = project.Actual;
            Estimated = project.Estimated;
        }
    }
}