using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Timers;

namespace Pomodoro_Logic
{
    public abstract class PomodoroStateTimer
    {
        public event EventHandler SessionTimerComplete;
        public event EventHandler SessionTimerTick;

        protected int numberOfBreaksTaken { get; private set; }
        protected Timer sessionTimer;
        protected Timer secondTickTimer;
        internal SessionConstants sessionConstants;

        private const int MILLISECONDS_IN_ONE_SECOND = 1_000;

        public PomodoroStateTimer(PomodoroStateTimer oldState)
        {
            numberOfBreaksTaken = getNumberOfBreaksTaken(oldState);
            sessionConstants = oldState.sessionConstants;
            createTimers();
            subscribeToTimers();
            startTimers();
        }

        private int getNumberOfBreaksTaken(PomodoroStateTimer oldState)
        {
            //if (oldState is LongBreak)
            //{
            //    return 0;
            //}

            return oldState.numberOfBreaksTaken + 1;
        }

        protected void subscribeToTimers()
        {
            sessionTimer.Elapsed += sessionTimer_Elapsed;
            secondTickTimer.Elapsed += secondTickTimer_Elapsed;
        }

        protected int getRemainingTime(Timer timer, int secondsToACompleteSession)
        {
            throw new NotImplementedException();
        }

        protected abstract void createTimers();

        protected Timer createTimer(int seconds)
        {
            var timer = new Timer(seconds * MILLISECONDS_IN_ONE_SECOND);
            return timer;
        }

        protected abstract void startTimers();

        protected abstract void sessionTimer_Elapsed(object sender, EventArgs e);
        protected abstract void secondTickTimer_Elapsed(object sender, EventArgs e);
    }
}
