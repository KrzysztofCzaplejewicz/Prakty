using System;
using System.Collections.Generic;

namespace TheWorkFlowEngine
{
    public class WorkFlowEngine
    {
        public void Run(IWorkFlow workFlow)
        {
            foreach (ITask I in workFlow.GetTasks())
            {
                I.Execute();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var workFlow = new WorkFlow(new List<ITask>());
            workFlow.Add(new CallWebService());
            workFlow.Add(new VideoUploader());
            workFlow.Add(new SendEmail());

            var workFlowEngine = new WorkFlowEngine();
            workFlowEngine.Run(workFlow);
        }
    }
}
