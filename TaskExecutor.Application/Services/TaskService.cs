using TaskExecutor.Core.Interfaces;

namespace TaskExecutor.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;

    public TaskService(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task ExecuteTaskAsync()
    {
        // Implementation will be added later
        await Task.CompletedTask;
    }
} 