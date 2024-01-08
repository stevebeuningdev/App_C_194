using TMPro;
using UnityEngine;

namespace CodeHub.OtherUtilities
{
    public class GameTimerUpdater : MonoBehaviour
    {
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private TMP_Text _gameTimeTxt;

        private void FixedUpdate()
        {
            UpdateTimeTxt();
        }

        private void UpdateTimeTxt()
        {
            _gameTimeTxt.text = _gameTimer.GetStringVisualizeTime(_gameTimer.SecondsFromStart);
        }
    }
}