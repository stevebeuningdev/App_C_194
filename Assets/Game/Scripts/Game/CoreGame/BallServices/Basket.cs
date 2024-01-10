using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class Basket : MonoBehaviour
    {
        public void MakeGentleShakeAnimation()
        {
            transform.DOKill();
            transform.DOShakePosition(0.3f, new Vector3(0.05f, 0.05f, 0), 2, 90, false, false).SetEase(Ease.InOutQuad);
        }
    }
}
