using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class Basket : MonoBehaviour
    {
        [field: SerializeField] public Transform MiddlePoint { get; private set; }
        [field: SerializeField] public Transform TopPoint { get; private set; }
        [field: SerializeField] public Transform GameLinePoint { get; private set; }
    }
}
