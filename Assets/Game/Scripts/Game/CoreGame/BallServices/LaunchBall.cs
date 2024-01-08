using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class LaunchBall : MonoBehaviour
    {
        [SerializeField] private Transform _startPosition;
        [field:SerializeField] public SpriteRenderer Icon;

        public void Initialize( Sprite icon)
        {
            UpdateIcon(icon);
        }

        public void SetStartPosition()
        {
            transform.position = _startPosition.position;
        }

        public void UpdateIcon(Sprite icon)
        {
            Icon.sprite = icon;
        }
    }
}