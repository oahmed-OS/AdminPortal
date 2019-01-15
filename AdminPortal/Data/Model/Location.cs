namespace AdminPortal.Data.Model
{
    public class Location : ITypeWithId
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RotationId { get; set; }
    }
}
