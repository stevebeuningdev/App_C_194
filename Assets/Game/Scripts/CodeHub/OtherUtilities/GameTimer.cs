using System;
using UnityEngine;

namespace CodeHub.OtherUtilities
{
    public class GameTimer : MonoBehaviour
    {
        private float _secondsFromStart;
        private bool _isPause;

        public float SecondsFromStart => _secondsFromStart;
        public Action OnEndTime;

        public void Initialize(float startTime)
        {
            _secondsFromStart = startTime;
            PauseTimer();
        }

        private void Update()
        {
            CoreTimer();
        }

        public string GetStringVisualizeTime(float time)
        {
            if (time >= 60)
            {
                return time + ":00";
            }

            if (time == 0)
            {
                return "00:00";
            }

            return TimeSpan.FromSeconds(time).ToString(@"ss\:ff");
        }

        public void PauseTimer()
        {
            _isPause = true;
        }

        public void StartTimer()
        {
            _isPause = false;
        }

        private void CoreTimer()
        {
            if (_isPause == true)
                return;

            _secondsFromStart -= Time.deltaTime;
            if (_secondsFromStart <= 0)
            {
                _secondsFromStart = 0;
                PauseTimer();
                OnEndTime?.Invoke();
            }
        }
    }
}