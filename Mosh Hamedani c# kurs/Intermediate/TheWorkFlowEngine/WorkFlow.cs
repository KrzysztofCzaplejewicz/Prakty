using System.Collections.Generic;

namespace TheWorkFlowEngine
{


    public class WorkFlow : IWorkFlow
    {
        private readonly List<ITask> _tasks;

        public WorkFlow(List<ITask> tasks)
        {
            _tasks = tasks;
        }

        public void Add(ITask task)
        {
            _tasks.Add(task);
        }

        public void Remove(ITask task)
        {
            _tasks.Remove(task);
        }
        public IEnumerable<ITask> GetTasks()
        {
            return _tasks;
        }
    }
}