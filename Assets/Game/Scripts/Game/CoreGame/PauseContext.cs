using DG.Tweening;
using Game.Mephistoss.PanelMachine.Scripts;
using Game.Scripts.Game.CoreGame.BallServices;
using Prototype.SceneLoaderCore.Helpers;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class PauseContext : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        
        [SerializeField] private PanelMachine _panelMachine;
        [SerializeField] private PanelBase _pausePanel;
        [SerializeField] private PanelBase _exitPanel;

        private bool _playerInputStatus;

        public void AddPausePanel()
        {
            ChangeTimeScale(0);
            _panelMachine.AddPanel(_pausePanel);
            PausePlayerInput(true);
        }

        public void ContinueGame()
        {
            ChangeTimeScale(1);
            _panelMachine.CloseLastPanel();
            
            PausePlayerInput(false);
        }

        public void ExitGame()
        {
            DOTween.KillAll();
            ChangeTimeScale(1);
            SceneLoader.Instance.SwitchToScene("Menu");
        }

        public void RestartGame()
        {
            DOTween.KillAll();
            ChangeTimeScale(1);
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

        private void PausePlayerInput(bool pause)
        {
            if (pause)
            {
                _playerInputStatus = _playerInputController.CanMove;
                _playerInputController.EnableMove(false);
            }
            else
            {
                _playerInputController.EnableMove(_playerInputStatus);
            }
        }
    }
}