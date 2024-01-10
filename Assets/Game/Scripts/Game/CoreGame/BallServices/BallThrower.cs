using Game.Scripts.Game.CoreGame.Infrastructure;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class BallThrower : MonoBehaviour
    {
        [field: SerializeField] public GameLine GameLine { get; private set; }
        [SerializeField] private BallsObjectPool _ballsObjectPool;

        [field: SerializeField] public float ThrowStateDuration = 3f;

        [SerializeField] private float _power = 5;
        [SerializeField] private Vector3 _maxSpeed;

        private GameContext _gameContext;
        private LaunchBall _launchBall;
        private Camera _mainCamera;

        public void Initialize(GameContext gameContext)
        {
            _launchBall = gameContext.LaunchBall;
            _gameContext = gameContext;
            _mainCamera = Camera.main;
            gameContext.PlayerInputController.OnStartMove += ChooseTarget;
            gameContext.PlayerInputController.OnEndMove += EndChooseTarget;
        }

        private void FixedUpdate()
        {
            GameLine.TryShowTrajectory(_launchBall.transform.position, GetSpeed());
        }

        private void ThrowBall()
        {
            var ball = GetInitBall();
            ball.Rigidbody2D.AddForce(GetSpeed(), ForceMode2D.Impulse);
        }

        private void ChooseTarget()
        {
            GameLine.EnableDraw(true);
        }

        private void EndChooseTarget()
        {
            GameLine.EnableDraw(false);
            ThrowBall();

            _gameContext.GameStateMachine.EnterState<ThrowBallState>();
        }

        private Vector3 GetSpeed()
        {
            var speed = (_mainCamera.ScreenToWorldPoint(Input.mousePosition) - _launchBall.transform.position) * _power;
            return GetClampSpeed(speed);
        }

        private Ball GetInitBall()
        {
            var ball = _ballsObjectPool.Pool.Get();

            ball.Initialize(_launchBall.Icon.sprite, _ballsObjectPool, _gameContext);
            ball.transform.position = _launchBall.transform.position;
            return ball;
        }

        private Vector3 GetClampSpeed(Vector3 speed)
        {
            var xSpeed = Mathf.Clamp(speed.x, -_maxSpeed.x, _maxSpeed.x);
            var ySpeed = Mathf.Clamp(speed.y, -_maxSpeed.y, _maxSpeed.y);
            var newSpeed = new Vector3(xSpeed, ySpeed, 0);
            return newSpeed;
        }
    }
}