using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class GameLine : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _points;
        [SerializeField] private float _timeOffset;
        [SerializeField] private Vector3 _scaleOffset;

        private bool _canDraw;

        private void Start()
        {
            ChangeScalePoints();
            EnableDraw(false);
        }

        public void EnableDraw(bool enable)
        {
            _canDraw = enable;
            foreach (var point in _points)
            {
                point.gameObject.SetActive(enable);
            }
        }

        public void TryShowTrajectory(Vector2 origin, Vector2 speed)
        {
            if (!_canDraw) return;

            for (int i = 0; i < _points.Count; i++)
            {
                float time = i * _timeOffset;
                _points[i].transform.position = origin + speed * time + Physics2D.gravity * time * time / 2f;
            }
        }

        [ContextMenu("ChangeScalePoints")]
        private void ChangeScalePoints()
        {
            int i = 0;
            foreach (var point in _points)
            {
                point.transform.localScale -= _scaleOffset * i;
                i++;
            }
        }
    }
}