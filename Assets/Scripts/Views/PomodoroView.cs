using Presenters;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroView : MonoBehaviour, IView
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] InputField customTimeIF;
    [SerializeField] GameObject panelCompleted;
    [SerializeField] TextMeshProUGUI completedPomodoroText;
    [SerializeField] GameObject timePanel;
    [SerializeField] GameObject createButtonsPomodoro;



    private PomodoroPresenter pomodoro;
    public event Action OnStart;
    public event Action OnInterrupt;
    public event Action OnRestart;
    public event Action<float> OnUpdate;
    public event Action<string> OnCreateCustomPomodoro;
    public event Action OnCreateStandardPomodoro;

    void Start()
    {
        pomodoro = new PomodoroPresenter();
        pomodoro.Initialize(this);

        InvokeRepeating("DecrementTime", 1, 1);
    }

    public void CreateStandardPomodoro()
    {
        OnCreateStandardPomodoro?.Invoke();
    }

    public void CreateCustomPomodoro()
    {
        if (customTimeIF.text.Length == 0) return;
        OnCreateCustomPomodoro?.Invoke(customTimeIF.text);
    }

    public void StartTime()
    {
        OnStart?.Invoke();

    }
    public void DecrementTime()
    {
        OnUpdate?.Invoke(Time.deltaTime);
    }
    public void Interrupt()
    {
        OnInterrupt?.Invoke();
    }
    public void Restart()
    {
        OnRestart?.Invoke();
    }

    public void UpdateTime(float time)
    {
        int minutes = ((int)time);
        int seconds = (int)((time - minutes) * 60);
        timeText.text = minutes.ToString() + ":" + seconds.ToString("D2");

    }

    public void FinishTime(string message)
    {
        timePanel.SetActive(false);
        createButtonsPomodoro.SetActive(false);
        panelCompleted.SetActive(true);
        completedPomodoroText.text = message;
    }



}
