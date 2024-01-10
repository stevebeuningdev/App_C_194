using System;
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
        public SpriteRenderer Visualize => _visualize;
        public BallsObjectPool BallsObjectPool { get; private set; }

        private GameContext _gameContext;
        private Tween _fadeTween;

        private bool _enterStartGate;
        private bool _hasActive;

        public bool EnterStartGate => _enterStartGate;

        public void Initialize(Sprite gameIcon, BallsObjectPool ballsObjectPool, GameContext gameContext)
        {
            _gameContext = gameContext;
            _visualize.sprite = gameIcon;
            _enterStartGate = false;
            _hasActive = true;

            BallsObjectPool = ballsObjectPool;
        }

        private void OnBecameInvisible()
        {
            ReleaseBall();
        }

        public void MakeFade()
        {
            if (!gameObject.activeSelf)
                return;

            _fadeTween = _visualize.DOFade(0, 2f).OnComplete(ReleaseBall);
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

        public void KillTween()
        {
            _fadeTween.Kill();
        }

        private void ReleaseBall()
        {
            if (!gameObject.activeSelf) return;

            DisableRigidbody();
            BallsObjectPool.Pool.Release(this);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            _gameContext.AudioContext.PlayHitBall();
            if (col.transform.GetComponent<Ground>() != null)
            {
                MakeFade();
            }
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.GetComponent<Gate>() != null)
            {
                _enterStartGate = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.transform.GetComponent<FinishGate>() != null)
            {
                if (_enterStartGate && _hasActive)
                {
                    _enterStartGate = false;
                    _hasActive = false;
                    _gameContext.MakeGoal();
                }
            }
        }
    }
}