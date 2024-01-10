using DG.Tweening;
using Game.Scripts.Game.CoreGame.BallServices;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameRandomizer : MonoBehaviour
    {
        [SerializeField] private ClampedPositions _basketPositions;
        [SerializeField] private ClampedPositions _ballPositions;
        [SerializeField] private float _minDistanceBetween = 3f;

        private LaunchBall _launchBall;
        private Basket _basket;

        public void Initialize(LaunchBall launchBall, Basket basket)
        {
            _launchBall = launchBall;
            _basket = basket;
        }

        public void RandomizePosition()
        {
            Vector3 randomBasketPosition = GetRandomPosition(_basketPositions);
            _basket.transform.DOKill();
            _basket.transform.DOMove(randomBasketPosition, 1.75f).SetEase(Ease.OutBack);
            RandomizeBallPosition(randomBasketPosition);
        }

        private void RandomizeBallPosition(Vector3 randomBasketPosition)
        {
            Vector3 randomBallPosition;
            do
            {
                randomBallPosition = GetRandomPosition(_ballPositions);
            } while (Mathf.Abs(randomBallPosition.x - randomBasketPosition.x) < _minDistanceBetween);

            _launchBall.transform.position = randomBallPosition;
        }

        private Vector3 GetRandomPosition(ClampedPositions clampedPositions)
        {
            float xPosition = Random.Range(clampedPositions.LeftPosition.position.x,
                clampedPositions.RightPosition.position.x);
            float yPosition = Random.Range(clampedPositions.BottomPosition.position.y,
                clampedPositions.TopPositon.position.y);
            return new Vector3(xPosition, yPosition, 0);
        }
    }
}