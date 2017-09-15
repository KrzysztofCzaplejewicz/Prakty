using System;

namespace Exercise1StopWatch
{
    public class Stopwatch
    {
        public DateTime Start;
        public DateTime Stop;


        public bool _running;

        public void start()
        {
            if (!_running)
            {
                Start = DateTime.Now;
                _running = true;
            }
            else
            {
                throw new InvalidOperationException("Stopwatch is already running!");
            }

        }
        public void stop(DateTime stop)
        {
            if (_running)
            {
                Stop = stop;
                _running = false;
            }
            else
            {
                throw new InvalidOperationException("Stopwatch is not running! ");
            }
        }
        public TimeSpan getInterval()
        {
            var duration = Stop - Start;

            return duration;
        }
    }
}