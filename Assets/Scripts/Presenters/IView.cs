using System;

namespace Presenters
{
    public interface IView
    {
        event Action<string> OnCreateCustomPomodoro;
        event Action OnCreateStandardPomodoro;
        event Action<float> OnUpdate;
        event Action OnStart;
        event Action OnInterrupt;
        event Action OnRestart;

        void UpdateTime(float time);
        void FinishTime(string message);
        void StartTime();
        void Interrupt();
    }
}