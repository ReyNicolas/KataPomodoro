using System;

namespace Models
{
    public class Pomodoro
    {
        public float Time { get { return time; } }
        private float time;
        public readonly float InitialTime;
        bool isStopped = true;
        bool isInterrupted = false;


        public Pomodoro()
        {
            InitialTime = 25;
            time = InitialTime;

        }
        public Pomodoro(float time)
        {
            InitialTime = time;
            this.time = InitialTime;
        }
        public bool IsInterrupted()
        {
            return isInterrupted;
        }

        public bool IsStopped()
        {
            return isStopped;
        }
        public void SubstractTime(float time)
        {
            if (isStopped || isInterrupted) return;
            this.time -= time;
            this.time = Math.Max(this.time, 0);

        }

        public void Start()
        {
            time = InitialTime;
            isStopped = false;
        }

        public void Interrupt()
        {
            if (isStopped) return;
            isInterrupted = true;
        }

        public void Restart()
        {
            if (!isInterrupted) return;
            Start();
            isInterrupted = false;
        }

        public bool IsFinished()
        {
            return (!isStopped) ? IsTimeOver() : false;
        }

        bool IsTimeOver()
            => Time == 0;


    }
}
