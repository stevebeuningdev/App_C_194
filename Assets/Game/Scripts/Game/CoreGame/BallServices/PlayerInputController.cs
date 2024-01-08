using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class PlayerInputController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private LaunchBall _launchBall;

        [SerializeField] private Transform _leftClamp;
        [SerializeField] private Transform _rightClamp;

        public Action OnStartMove;
        public Action OnEndMove;

        private bool _canMove;
        private bool _hasUiOver;
        

        public void EnableMove(bool enable)
        {
            _canMove = enable;
        }

        private void OnMouseDrag()
        {
            if (!_canMove || _hasUiOver) return;

            MoveBall();
        }

        private void OnMouseDown()
        {
            _hasUiOver = HasUiOver();
            if (!_canMove || _hasUiOver) return;

            Debug.Log("down click");
            OnStartMove?.Invoke();
        }

        private void OnMouseUp()
        {
            if (!_canMove || _hasUiOver) return;

            Debug.Log("up click");
            OnEndMove?.Invoke();
        }

        private void MoveBall()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var clamPosition = GetClampPosition(mousePosition);

            Move(clamPosition);
        }

        private void Move(Vector3 targetPosition)
        {
            _launchBall.transform.position = Vector3.Lerp(_launchBall.transform.position, targetPosition,
                Time.deltaTime * _moveSpeed);
        }

        private Vector3 GetClampPosition(Vector3 position)
        {
            var xPosition = Mathf.Clamp(position.x, _leftClamp.position.x, _rightClamp.position.x);
            var yPosition = _launchBall.transform.position.y;
            var newPosition = new Vector3(xPosition, yPosition, 0);
            return newPosition;
        }

        private bool HasUiOver()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}