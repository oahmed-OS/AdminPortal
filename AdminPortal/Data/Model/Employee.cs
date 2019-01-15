namespace AdminPortal.Data.Model
{
    public class Employee : ITypeWithId
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserId { get; set; }

        public int DepartmentId { get; set; }
    }
}
