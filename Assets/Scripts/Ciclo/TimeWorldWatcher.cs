using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using System.Linq;

public class TimeWorldWatcher : MonoBehaviour
{
    [SerializeField]
    private WorldTime worldTime;

    [SerializeField]
    private List<Schedule> schedule;

    private void Start()
    {
        worldTime.WorldTimeChanged += CheckSchedule;
    }

    private void OnDestroy()
    {
        worldTime.WorldTimeChanged -= CheckSchedule;
    }

    private void CheckSchedule(object sender, TimeSpan newTime)
    {
        var matchedSchedule = schedule.FirstOrDefault(s => s.Hour == newTime.Hours && s.Minute == newTime.Minutes);

        matchedSchedule?.action.Invoke();
    }

    [Serializable]
    private class Schedule
    {
        public int Hour;
        public int Minute;
        public int Day;
        public UnityEvent action;
    }
}
