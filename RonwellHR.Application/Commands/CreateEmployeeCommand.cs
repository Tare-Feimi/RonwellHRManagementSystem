using MediatR;

namespace RonwellHR.Application.Employees.Commands
{
    public class CreateEmployeeCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Qualification { get; set; }
        public string Skills { get; set; }
        public int Experience { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
    }
}
