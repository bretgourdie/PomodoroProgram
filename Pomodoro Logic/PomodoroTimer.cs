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
        public int StartingMinutes { get; }

        private Timer timer;

        private const int NumberOfMillisecondsInOneSecond = 1000;

        public PomodoroTimer(int minutes)
        {
            this.StartingMinutes = minutes;
            timer = new Timer(NumberOfMillisecondsInOneSecond);
        }

        public void Start()
        {
        }

        public void Pause()
        {

        }

        public void Stop()
        {

        }
    }
}
