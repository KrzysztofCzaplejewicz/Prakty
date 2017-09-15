using System;

namespace TheWorkFlowEngine
{
    public class VideoUploader : ITask
    {
        public void Execute()
        {
            Console.WriteLine("Uploading a video...");
        }
    }
}