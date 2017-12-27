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
        public int StartingSeconds { get; private set; }

        private int currentSeconds { get; set; }

        private Timer timer { get; set; }

        private const int NumberOfMillisecondsInOneSecond = 1000;

        public PomodoroTimer(int seconds)
        {
            this.StartingSeconds = seconds;
            this.timer = getTimer();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            decrementTimeRemaining();
            throw new NotImplementedException("Publish Tick");
            if (!IsRunning())
            {
                Stop();
                throw new NotImplementedException("Publish End");
            }
        }

        public void Start()
        {
            this.timer.Start();
        }

        public void Stop()
        {
            this.timer.Stop();
        }

        public void Reset(bool stopTimer = true)
        {
            resetAndStopTimer(stopTimer);
        }

        private void resetAndStopTimer(bool stopTimer)
        {
            this.currentSeconds = this.StartingSeconds;

            if (stopTimer)
            {
                this.timer = getTimer();
            }
        }

        public bool IsRunning()
        {
            return this.currentSeconds != 0;
        }

        private void decrementTimeRemaining()
        {
            this.currentSeconds -= 1;
        }

        private Timer getTimer()
        {
            var timer = new Timer(NumberOfMillisecondsInOneSecond);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            return timer;
        }
    }
}
