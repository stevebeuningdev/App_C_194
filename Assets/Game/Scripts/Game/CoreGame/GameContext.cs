using CodeHub.OtherUtilities;
using Game.Scripts.Game.CoreGame.BallServices;
using Game.Scripts.Game.CoreGame.Infrastructure;
using TMPro;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameContext : MonoBehaviour
    {
        [field: SerializeField] public LaunchBall LaunchBall;
        [field: SerializeField] public PlayerInputController PlayerInputController;
        [field: SerializeField] public BallThrower BallThrower;
        [field: SerializeField] public GameOverContext GameOverContext;
        [field: SerializeField] public GameObject BallsParent;
        [field: SerializeField] public AudioContext AudioContext;

        [SerializeField] private Basket _basket;
        [SerializeField] private GameTimer _gameTimer;
        [SerializeField] private GameRandomizer _gameRandomizer;

        [SerializeField] private int _gameDuration;
        [SerializeField] private TMP_Text _scoreTxt;
        [SerializeField] private TMP_Text _goalTxt;

        public int Score { get; private set; }
        public int Goal { get; private set; }
        public bool HasEndGame { get; private set; }

        public GameStateMachine GameStateMachine { get; private set; }

        private int _plusScore = 10;

        public void Initialize(Sprite ballIcon)
        {
            InitTimer();
            LaunchBall.Initialize(ballIcon);
            BallThrower.Initialize(this);
            _gameRandomizer.Initialize(LaunchBall, _basket);

            GameStateMachine = new GameStateMachine(this);
            GameStateMachine.EnterState<StartState>();
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

            _gameRandomizer.RandomizePosition();

            AudioContext.PlayGoal();
        }

        public void SetScore(int newScore)
        {
            Score = newScore;
            UpdateScoreTxt();
        }

        private void AddGameOver()
        {
            HasEndGame = true;
            GameStateMachine.EnterState<EndGameState>();
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