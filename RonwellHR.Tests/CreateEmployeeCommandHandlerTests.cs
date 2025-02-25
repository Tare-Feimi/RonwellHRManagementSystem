using Xunit;
using Moq;
using RonwellHR.Application.Employees.Commands;
using RonwellHR.Data.Repositories;
using RonwellHR.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;

namespace RonwellHR.Tests
{
    public class CreateEmployeeCommandHandlerTests
    {
        [Fact]
        public async Task Handle_GivenValidCommand_ShouldAddEmployeeAndReturnId()
        {
            // Arrange
            var mockRepo = new Mock<IEmployeeRepository>();
            mockRepo.Setup(repo => repo.AddEmployeeAsync(It.IsAny<Employee>()))
                .Returns(Task.CompletedTask)
                .Callback<Employee>(employee => employee.EmployeeId = 1);

            var handler = new CreateEmployeeCommandHandler(mockRepo.Object);
            var command = new CreateEmployeeCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Qualification = "Bachelor",
                Skills = "C#, ASP.NET",
                Experience = 5,
                LoginId = "johndoe",
                Password = "password123"
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().Be(1);
            mockRepo.Verify(r => r.AddEmployeeAsync(It.IsAny<Employee>()), Times.Once);
        }
    }
}
