using DG.Tweening;
using UnityEngine;
using UnityEngine.Pool;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class BallsObjectPool : MonoBehaviour
    {
        [SerializeField] private Ball _ballPrefab;
        [SerializeField] private Transform _ballsParentTransform;

        public ObjectPool<Ball> Pool { get; private set; }

        private void Start()
        {
            Pool = new ObjectPool<Ball>(CreateBall, GetBall, ReleaseBall);
        }

        private void GetBall(Ball ball)
        {
            InitBall(ball);
            ball.gameObject.SetActive(true);
        }

        private void ReleaseBall(Ball ball)
        {
            ball.gameObject.SetActive(false);
        }

        private Ball CreateBall()
        {
            var ball = Instantiate(_ballPrefab, _ballsParentTransform);
            InitBall(ball);
            return ball;
        }

        private void InitBall(Ball ball)
        {
            ball.transform.localScale = Vector3.one;
            ball.EnableRigidbody();
            ball.KillTween();
            ball.Visualize.DOKill();
            ball.Visualize.color = Color.white;
            ball.transform.rotation = Quaternion.identity;
        }
    }
}