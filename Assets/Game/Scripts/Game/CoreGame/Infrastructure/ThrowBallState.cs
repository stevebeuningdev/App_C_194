using CodeHub.StateMachine;
using DG.Tweening;

namespace Game.Scripts.Game.CoreGame.Infrastructure
{
    public class ThrowBallState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameContext gameContext;

        public ThrowBallState(GameStateMachine gameStateMachine, GameContext gameContext)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameContext = gameContext;
        }

        public void Exit()
        {
        }

        public void Enter()
        {
            gameContext.LaunchBall.gameObject.SetActive(false);
            DOVirtual.DelayedCall(gameContext.BallThrower.ThrowStateDuration, () => EnterStartState());
        }

        private void EnterStartState()
        {
            if (gameContext.HasEndGame == false)
            {
                gameStateMachine.EnterState<StartState>();
            }
        }
    }
}