using System;

namespace TheWorkFlowEngine
{
    public class SendEmail : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Sending email...");
        }
    }
}