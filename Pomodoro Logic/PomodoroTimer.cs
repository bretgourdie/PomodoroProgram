using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Pomodoro_Logic
{
    public class PomodoroTimer
    {
        public int WorkingSessionSeconds { get; private set; }
        public int RestSessionSeconds { get; private set; }

        public event EventHandler Tick;
        public event EventHandler SessionComplete;
        public event EventHandler WorkingSessionComplete;
        public event EventHandler RestSessionComplete;

        private Timer currentTimer { get; set; }

        private Timer workingTimer { get; set; }
        private Timer restTimer { get; set; }

        private Timer tickingTimer { get; set; }

        private const int NumberOfMillisecondsInOneSecond = 1000;

        public PomodoroTimer(int workingSessionSeconds, int restSessionSeconds)
        {
            this.WorkingSessionSeconds = workingSessionSeconds;
            this.RestSessionSeconds = RestSessionSeconds;
        }

        public void Start()
        {
            setTimers(true);
        }

        public void Stop()
        {
            setTimers(false);
        }

        public void Reset(bool stopTimer = true)
        {
            Start();
            Stop();
        }

        private void setTimers(bool start)
        {
            var timers = new Timer[] { currentTimer, tickingTimer };

            foreach(var timer in timers)
            {
                if (start)
                {
                    timer.Start();
                }
                else
                {
                    timer.Stop();
                }
            }
        }

        private EventArgs getEventArgs()
        {
            return new EventArgs();
        }

        private Timer getNewTickingTimer(int interval)
        {
            var timer = getTimer(interval, true);
            timer.Elapsed += tickingTimerElapsed;
            return timer;
        }

        private void tickingTimerElapsed(object sender, EventArgs e)
        {
            Tick(this, getEventArgs());
        }

        private Timer getNewWorkingTimer(int interval)
        {
            var timer = getTimer(interval, false);
            timer.Elapsed += workingTimerElapsed;
            return timer;
        }

        private void workingTimerElapsed(object sender, EventArgs e)
        {
            WorkingSessionComplete(this, getEventArgs());
            SessionComplete(this, getEventArgs());
        }

        private Timer getNewRestTimer(int interval)
        {
            var timer = getTimer(interval, false);
            timer.Elapsed += restTimerElapsed;
            return timer;
        }

        private void restTimerElapsed(object sender, EventArgs e)
        {
            RestSessionComplete(this, getEventArgs());
            SessionComplete(this, getEventArgs());
        }

        private Timer getTimer(int interval, bool autoReset)
        {
            var timer = new Timer(interval)
            {
                AutoReset = autoReset
            };
            return timer;
        }
    }
}
