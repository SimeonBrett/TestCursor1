using TaskExecutor.Core.Interfaces;

namespace TaskExecutor.Infrastructure.Persistence;

public class TaskRepository : ITaskRepository
{
    public async Task<bool> SaveAsync()
    {
        // Will be implemented later when we add actual database
        await Task.CompletedTask;
        return true;
    }
} 