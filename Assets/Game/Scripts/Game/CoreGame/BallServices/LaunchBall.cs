using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class LaunchBall : MonoBehaviour
    {
        [field: SerializeField] public SpriteRenderer Icon;

        public void Initialize(Sprite icon)
        {
            UpdateIcon(icon);
        }

        private void UpdateIcon(Sprite icon)
        {
            Icon.sprite = icon;
        }
    }
}