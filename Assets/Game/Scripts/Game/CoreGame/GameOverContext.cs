using System;
using CodeHub.OtherUtilities;
using Game.Mephistoss.PanelMachine.Scripts;
using TMPro;
using Tools.UnityAdsService.Scripts;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Game.CoreGame
{
    public class GameOverContext : MonoBehaviour
    {
        [SerializeField] private PlayerDatabase _playerDatabase;
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private PanelMachine _panelMachine;
        [SerializeField] private PanelBase _gameOverPanel;

        [SerializeField] private TMP_Text _bestGaolsTxt;
        [SerializeField] private TMP_Text _currentGoalsTxt;
        [SerializeField] private TMP_Text _rewardTxt;
        [SerializeField] private TMP_Text _watchAdsTxt;

        [SerializeField] private Button _adsBtn;
        [SerializeField] private UnityAdsButton _unityAdsButton;

        private void Start()
        {
            _unityAdsButton.OnCanGetReward += GetRewardFromAds;
        }

        public void AddGameOverPanel()
        {
            _panelMachine.AddPanel(_gameOverPanel);
            UpdateTxt();
        }

        public void CheckBestGoalsCount()
        {
            if (_gameContext.Goal > _playerDatabase.BestGoal)
            {
                _playerDatabase.BestGoal = _gameContext.Goal;
            }
        }

        public void GetReward()
        {
            _playerDatabase.IncreasePlayerBalance(_gameContext.Score);
        }

        private void GetRewardFromAds()
        {
            _adsBtn.interactable = false;
            GetReward();
            _gameContext.SetScore(_gameContext.Score * 2);
        }

        private void UpdateTxt()
        {
            _bestGaolsTxt.text = _playerDatabase.BestGoal + "";
            _currentGoalsTxt.text = _gameContext.Goal + "";
            _rewardTxt.text = _gameContext.Score + "<sprite=0>";
            _watchAdsTxt.text = "Watch the ad and get " + _gameContext.Score * 2;
        }
    }
}