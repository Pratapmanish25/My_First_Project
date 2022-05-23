namespace EMSProject.Controllers
{
    public class Employee
    {
        public int Id { get; /*internal*/ set; }
        public string FirstName { get; /*internal*/ set; }
        public string LastName { get; /*internal*/ set; }
        public string Email { get; /*internal*/ set; }
        public string Mobile { get; /*internal*/ set; }
        public string Image { get; /*internal*/ set; }
        public bool IsActive { get; /*internal*/ set; }
    }
}