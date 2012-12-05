namespace ProjectBilling.Web.Entities
{
    public class Project : IProject
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public decimal Actual { get; set; }

        public decimal Estimated { get; set; }
    }
}