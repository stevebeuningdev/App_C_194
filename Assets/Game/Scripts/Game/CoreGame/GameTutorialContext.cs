using CodeHub.OtherUtilities;
using DG.Tweening;
using Game.Scripts.Game.CoreGame.BallServices;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameTutorialContext : MonoBehaviour
    {
        [SerializeField] private PlayerInputController _playerInputController;
        [SerializeField] private GameContext _gameContext;
        [SerializeField] private PlayerDatabase _playerDatabase;
        [SerializeField] private GameObject _tutorialElements;
        [SerializeField] private GameObject _tutorialPoints;
        [SerializeField] private GameObject _animHand;

        public void Initialize()
        {
            CheckTutorial();
        }

        private void DisableTutorial()
        {
            _tutorialElements.gameObject.SetActive(false);
            DOTween.Kill(_animHand.transform);
            
            _playerInputController.OnEndMove -= DisableTutorial;
            _playerInputController.OnStartMove -= DisableTutorialPoints;
            
            _gameContext.GameTimer.StartTimer();
        }

        private void CheckTutorial()
        {
            if (HasSeenTutorial()) return;

            _tutorialElements.gameObject.SetActive(true);
            _playerDatabase.HasSeenFirstTutorial = true;
            
            _gameContext.GameTimer.PauseTimer();

            AnimateHand();

            _playerInputController.OnEndMove += DisableTutorial;
            _playerInputController.OnStartMove += DisableTutorialPoints;
        }

        private void DisableTutorialPoints()
        {
            _tutorialPoints.gameObject.SetActive(false);
        }

        private void AnimateHand()
        {
            _animHand.transform.DORotate(new Vector3(0f, 0f, 40), 0.7f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.Linear);
        }

        private bool HasSeenTutorial() => _playerDatabase.HasSeenFirstTutorial;
    }
}