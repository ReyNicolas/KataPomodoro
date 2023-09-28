using Models;
namespace Presenters
{
    public class PomodoroPresenter
    {
        private IView view;
        private Pomodoro pomodoro;

        public void Initialize(IView view)
        {
            this.view = view;
            CreateStandardPomodoro();
            view.OnCreateCustomPomodoro += CreateCustomPomodoro;
            view.OnCreateStandardPomodoro += CreateStandardPomodoro;
            view.OnStart += StartPomodoro;
            view.OnUpdate += SubstractTime;
            view.OnRestart += RestartPomodoro;
            view.OnInterrupt += InterruptPomodoro;
        }

        private void CreateCustomPomodoro(string time)
        {
            pomodoro = new Pomodoro(float.Parse(time));
            view.UpdateTime(pomodoro.Time);
        }

        private void CreateStandardPomodoro()
        {
            pomodoro = new Pomodoro();
            view.UpdateTime(pomodoro.Time);
        }


        private void StartPomodoro()
        {
            if (!pomodoro.IsStopped())
                return;

            pomodoro.Start();
            view.UpdateTime(pomodoro.Time);
        }

        private void SubstractTime(float time)
        {
            if (pomodoro.IsStopped())
                return;

            pomodoro.SubstractTime(time);
            view.UpdateTime(pomodoro.Time);

            if (pomodoro.IsFinished())
            {
                view.FinishTime("Felicidades, completaste el Pomodoro");
            }
        }
        private void InterruptPomodoro()
        {
            if (pomodoro.IsStopped())
                return;
            pomodoro.Interrupt();
        }

        private void RestartPomodoro()
        {
            if (!pomodoro.IsInterrupted())
                return;
            pomodoro.Restart();
        }
    }
}