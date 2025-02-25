namespace RonwellHR.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string Skills { get; set; }
        public int Experience { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }

        public bool IsHired { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
