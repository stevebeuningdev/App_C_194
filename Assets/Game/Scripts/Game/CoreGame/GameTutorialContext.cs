using CodeHub.OtherUtilities;
using DG.Tweening;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class GameTutorialContext : MonoBehaviour
    {
        [SerializeField] private PlayerDatabase _playerDatabase;
        [SerializeField] private GameObject _tutorialElements;
        [SerializeField] private GameObject _animHand;

        private void Start()
        {
            CheckTutorial();
            //todo disable tutorial after make first move
        }

        public void DisableTutorial()
        {
            _tutorialElements.gameObject.SetActive(false);
            DOTween.Kill(_animHand.transform);
        }

        private void CheckTutorial()
        {
            if (HasSeenTutorial()) return;

            _tutorialElements.gameObject.SetActive(true);
            AnimateHand();
            _playerDatabase.HasSeenFirstTutorial = true;
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