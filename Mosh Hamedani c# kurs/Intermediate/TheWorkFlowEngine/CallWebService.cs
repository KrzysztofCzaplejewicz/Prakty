using System;

namespace TheWorkFlowEngine
{
    public class CallWebService : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Calling web service...");
        }
    }
}