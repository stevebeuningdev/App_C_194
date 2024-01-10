using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class Wall : MonoBehaviour
    {
        [SerializeField] private Basket _basket;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.GetComponent<Ball>() != null)
            {
                var ball = col.transform.GetComponent<Ball>();
                if (!ball.EnterStartGate)
                    _basket.MakeGentleShakeAnimation();
            }
        }
    }
}