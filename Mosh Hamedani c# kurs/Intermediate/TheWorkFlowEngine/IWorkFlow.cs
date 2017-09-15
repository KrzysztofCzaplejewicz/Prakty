using System.Collections.Generic;

namespace TheWorkFlowEngine
{
    public interface IWorkFlow
    {
        void Add(ITask task);
        void Remove(ITask task);
        IEnumerable<ITask> GetTasks();
    }
}