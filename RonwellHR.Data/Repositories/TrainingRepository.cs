using RonwellHR.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace RonwellHR.Data.Repositories
{
    public interface ITrainingRepository
    {
        Task AddTrainingSessionAsync(TrainingSession session);
        Task<IEnumerable<TrainingSession>> GetTrainingSessionsByEmployeeIdAsync(int employeeId);
        Task<IEnumerable<TrainingSession>> GetAllTrainingSessionsAsync();
    }

    public class TrainingRepository : ITrainingRepository
    {
        private readonly HRDbContext _context;
        public TrainingRepository(HRDbContext context)
        {
            _context = context;
        }

        public async Task AddTrainingSessionAsync(TrainingSession session)
        {
            await _context.TrainingSessions.AddAsync(session);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainingSession>> GetTrainingSessionsByEmployeeIdAsync(int employeeId)
        {
            return await _context.TrainingSessions
                .Where(ts => ts.EmployeeId == employeeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<TrainingSession>> GetAllTrainingSessionsAsync()
        {
            return await _context.TrainingSessions.ToListAsync();
        }
    }
}
