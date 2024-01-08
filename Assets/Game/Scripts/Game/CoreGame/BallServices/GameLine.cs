using UnityEngine;

namespace Game.Scripts.Game.CoreGame.BallServices
{
    public class GameLine : MonoBehaviour
    {
        [SerializeField] private Vector2 _testSpeed;
        [SerializeField] private LaunchBall _launch;

        [SerializeField] private int _pointsCount = 34;
        [SerializeField] private LineRenderer _lineRenderer;

        private void FixedUpdate()
        {
            ShowTrajectory(_launch.transform.position, _testSpeed);
        }

        private void ShowTrajectory(Vector2 origin, Vector2 speed)
        {
            Vector3[] points = new Vector3[_pointsCount];
            _lineRenderer.positionCount = points.Length;
            for (int i = 0; i < points.Length; i++)
            {
                float time = i * 0.1f;
                points[i] = origin + speed * time + Physics2D.gravity * time * time / 2f;

                // if (points[i].y < 0)
                // {
                //     _lineRenderer.positionCount = i + 1;
                //     break;
                // }
            }

            _lineRenderer.SetPositions(points);
        }
    }
}