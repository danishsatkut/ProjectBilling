namespace ProjectBilling.DataAccess.Entities
{
    public interface IProject
    {
        string Name { get; set; }

        int Id { get; set; }

        decimal Actual { get; set; }

        decimal Estimated { get; set; }

        void Update(IProject project);
    }
}