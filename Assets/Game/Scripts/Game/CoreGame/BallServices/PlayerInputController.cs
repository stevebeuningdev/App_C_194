using System;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class PlayerInputController : MonoBehaviour
    {
        public Action OnStartMove;
        public Action OnEndMove;

        private bool _canMove;
        private bool _hasDownClick;

        public bool CanMove => _canMove;

        public void EnableMove(bool enable)
        {
            _canMove = enable;
        }

        private void OnMouseDown()
        {
            if (!_canMove) return;

            Debug.Log("down click");
            _hasDownClick = true;
            OnStartMove?.Invoke();
        }

        private void OnMouseUp()
        {
            if (!_canMove || !_hasDownClick) return;

            Debug.Log("up click");
            _hasDownClick = false;
            OnEndMove?.Invoke();
        }
    }
}