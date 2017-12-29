using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro_Logic
{
    public class ShortBreakStart : PomodoroStateTimer
    {
        public ShortBreakStart(PomodoroStateTimer oldState) : base(oldState)
        {
        }

        protected override void createSessionTimer()
        {
            sessionTimer = createTimer(sessionConstants.ShortBreakTimeInSeconds);
        }
    }
}
