using RonwellHR.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RonwellHR.Data.Repositories
{
    public interface IProjectRepository
    {
        Task AddProjectAsync(Project project);
        Task<IEnumerable<Project>> GetProjectsByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }

    public class ProjectRepository : IProjectRepository
    {
        private readonly HRDbContext _context;

        public ProjectRepository(HRDbContext context)
        {
            _context = context;
        }

        public async Task AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Project>> GetProjectsByEmployeeIdAsync(int employeeId)
        {
            return await _context.Projects
                .Where(p => p.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }
    }
}
