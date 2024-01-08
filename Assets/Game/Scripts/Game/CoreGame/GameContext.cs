using CodeHub.OtherUtilities;
using Game.Scripts.Game.CoreGame.BallServices;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameContext : MonoBehaviour
    {
        [field: SerializeField] public LaunchBall LaunchBall;

        [SerializeField] private GameOverContext _gameOverContext;
        [SerializeField] private int _gameDuration;
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private TMP_Text _scoreTxt;
        [SerializeField] private TMP_Text _goalTxt;

        public int Score { get; private set; }
        public int Goal { get; private set; }

        private int _plusScore = 10;

        public void Initialize(Sprite ballIcon)
        {
            InitTimer();
            LaunchBall.Initialize(ballIcon);
        }

        private void InitTimer()
        {
            _gameTimer.Initialize(_gameDuration);
            _gameTimer.StartTimer();

            _gameTimer.OnEndTime += AddGameOver;
        }

        public void MakeGoal()
        {
            Goal++;
            UpdateGoalTxt();

            AddScore();
        }

        public void SetScore(int newScore)
        {
            Score = newScore;
            UpdateScoreTxt();
        }

        private void AddGameOver()
        {
            _gameOverContext.CheckBestGoalsCount();
            _gameOverContext.GetReward();
            _gameOverContext.AddGameOverPanel();
        }

        private void AddScore()
        {
            Score += _plusScore;
            UpdateScoreTxt();
        }

        private void UpdateScoreTxt()
        {
            _scoreTxt.text = Score + "";
        }

        private void UpdateGoalTxt()
        {
            _goalTxt.text = Goal + "";
        }
    }
}