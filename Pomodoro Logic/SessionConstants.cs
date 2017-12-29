using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pomodoro_Logic
{
    /// <summary>
    /// Containter for constant numbers for the current session.
    /// </summary>
    internal class SessionConstants
    {
        /// <summary>
        /// The number of seconds in one Pomodoro.
        /// </summary>
        public int PomodoroTimeInSeconds { get; private set; }
        /// <summary>
        /// The number of seconds in a short break.
        /// </summary>
        public int ShortBreakTimeInSeconds { get; private set; }
        /// <summary>
        /// The number of seconds in a long break.
        /// </summary>
        public int LongBreakTimeInSeconds { get; private set; }
        /// <summary>
        /// The number of Pomodoros per one long break.
        /// </summary>
        public int NumberOfPomodorosPerLongBreak { get; private set; }

        /// <summary>
        /// Creates a container for session constants.
        /// </summary>
        /// <param name="pomodoroTimeInSeconds">The number of seconds in one Pomodoro.</param>
        /// <param name="shortBreakTimeInSeconds">The number of seconds in a short break.</param>
        /// <param name="longBreakTimeInSeconds">The number of seconds in a long break.</param>
        /// <param name="numberOfPomodorosPerLongBreak">The number of Pomodoros before a long break.</param>
        public SessionConstants(
            int pomodoroTimeInSeconds,
            int shortBreakTimeInSeconds,
            int longBreakTimeInSeconds,
            int numberOfPomodorosPerLongBreak)
        {
            PomodoroTimeInSeconds = pomodoroTimeInSeconds;
            ShortBreakTimeInSeconds = shortBreakTimeInSeconds;
            LongBreakTimeInSeconds = longBreakTimeInSeconds;
            NumberOfPomodorosPerLongBreak = numberOfPomodorosPerLongBreak;
        }
    }
}
