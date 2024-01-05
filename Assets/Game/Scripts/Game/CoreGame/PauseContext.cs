using DG.Tweening;
using Game.Mephistoss.PanelMachine.Scripts;
using Prototype.SceneLoaderCore.Helpers;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class PauseContext : MonoBehaviour
    {
        [SerializeField] private PanelMachine _panelMachine;
        [SerializeField] private PanelBase _pausePanel;
        [SerializeField] private PanelBase _exitPanel;

        public void AddPausePanel()
        {
            ChangeTimeScale(0);
            _panelMachine.AddPanel(_pausePanel);
        }

        public void ContinueGame()
        {
            ChangeTimeScale(1);
            _panelMachine.CloseLastPanel();
        }

        public void ExitGame()
        {
            ChangeTimeScale(1);
            DOTween.KillAll();
            SceneLoader.Instance.SwitchToScene("Menu");
        }

        public void RestartGame()
        {
            ChangeTimeScale(1);
            DOTween.KillAll();
            SceneLoader.Instance.SwitchToScene("Game");
        }

        public void AddExitPanel()
        {
            _panelMachine.CloseLastPanel();
            _panelMachine.AddPanel(_exitPanel);
        }

        public void BackToPause()
        {
            _panelMachine.CloseLastPanel();
            _panelMachine.AddPanel(_pausePanel);
        }

        private void ChangeTimeScale(int scale)
        {
            Time.timeScale = scale;
            DOTween.timeScale = scale;
        }
    }
}