using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class BallThrower : MonoBehaviour
    {
        [field: SerializeField] public GameLine GameLine { get; private set; }
        [SerializeField] private BallsObjectPool _ballsObjectPool;
        [SerializeField] private float _throwDuration;
        [field: SerializeField] public float ThrowStateDuration = 3f;

        [SerializeField] private Basket _basket;

        private GameContext _gameContext;
        private LaunchBall _launchBall;

        public void Initialize(GameContext gameContext)
        {
            _launchBall = gameContext.LaunchBall;
            _gameContext = gameContext;
        }

        public void ThrowBall()
        {
            var ball = GetInitBall();
            ThrowAnimation(ball);
        }

        private Ball GetInitBall()
        {
            var ball = _ballsObjectPool.Pool.Get();

            ball.DisableRigidbody();

            ball.Initialize(_launchBall.Icon.sprite, _ballsObjectPool, _gameContext);
            ball.transform.position = _launchBall.transform.position;
            return ball;
        }

        private void ThrowAnimation(Ball ball)
        {
            ball.transform.DOJump(_basket.TopPoint.position, 1f, 1, _throwDuration).SetEase(Ease.Linear)
                .OnComplete((
                    () =>
                    {
                        ball.EnableRigidbody();
                        ball.Rigidbody2D.velocity = Vector2.down * 10f;
                        //ball.Rigidbody2D.AddForce(Vector2.down * 100);
                    }));
        }
    }
}