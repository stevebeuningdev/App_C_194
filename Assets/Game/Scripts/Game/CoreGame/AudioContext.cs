using CodeHub.OtherUtilities;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame
{
    public class AudioContext : MonoBehaviour
    {
        [SerializeField] private PlayerDatabase _playerDatabase;
        [SerializeField] private AudioSource _winGame;
        [SerializeField] private AudioSource _throwBall;
        [SerializeField] private AudioSource _hitBall;
        [SerializeField] private AudioSource _goal;
        [SerializeField] private AudioSource _reward;
        
        public void PlayWinGame()
        {
            _winGame.Play();
        }

        public void PlayThrowBall()
        {
            _throwBall.Play();
        }

        public void PlayGoal()
        {
            _goal.Play();
        }

        public void PlayReward()
        {
            _reward.Play();
        }

        public void PlayHitBall()
        {
            _hitBall.Play();
        }
    }
}