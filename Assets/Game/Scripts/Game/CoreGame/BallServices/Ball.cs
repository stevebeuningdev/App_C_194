using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _visualize;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Collider2D _collider2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public Collider2D Collider2D => _collider2D;
        public BallsObjectPool BallsObjectPool { get; private set; }

        private GameContext _gameContext;

        public void Initialize( Sprite gameIcon,BallsObjectPool ballsObjectPool, GameContext gameContext)
        {
            _gameContext = gameContext;
            _visualize.sprite = gameIcon;

            BallsObjectPool = ballsObjectPool;
        }

        public void Break()
        {
            DisableRigidbody();

            //todo make fade ball
            
            transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InOutBack)
                .OnComplete(() => BallsObjectPool.Pool.Release(this));
        }

        public void DisableRigidbody()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Static;
            _collider2D.enabled = false;
        }

        public void EnableRigidbody()
        {
            _rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
            _collider2D.enabled = true;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            var otherBall = col.transform.GetComponent<Ball>();

            if (otherBall != null )
            {
                //BallBreaker.TryBreakConnectedBalls(this);
            }
        }
    }
}