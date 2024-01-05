using TMPro;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameContext : MonoBehaviour
    {
        [SerializeField] private GameOverContext _gameOverContext;
        [SerializeField] private TMP_Text _scoreTxt;
        [SerializeField] private TMP_Text _goalTxt;

        public int Score { get; private set; }
        public int Goal { get; private set; }

        private int _plusScore = 10;

        public void MakeGoal()
        {
            Goal++;
            UpdateGoalTxt();

            AddScore();
        }

        public void AddGameOver()
        {
            _gameOverContext.CheckBestGoalsCount();
            _gameOverContext.GetReward();
            _gameOverContext.AddGameOverPanel();
        }

        public void SetScore(int newScore)
        {
            Score = newScore;
            UpdateScoreTxt();
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