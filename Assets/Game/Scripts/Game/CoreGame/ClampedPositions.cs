using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class ClampedPositions : MonoBehaviour
    {
        [field:SerializeField] public Transform TopPositon;
        [field:SerializeField] public Transform BottomPosition;
        [field:SerializeField] public Transform LeftPosition;
        [field:SerializeField] public Transform RightPosition;
    }
}