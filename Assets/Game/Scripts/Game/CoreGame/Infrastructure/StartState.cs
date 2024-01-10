using CodeHub.StateMachine;

namespace Game.Scripts.Game.CoreGame.Infrastructure
{
    public class StartState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameContext gameContext;

        public StartState(GameStateMachine gameStateMachine, GameContext gameContext)
        {
            this.gameStateMachine = gameStateMachine;
            this.gameContext = gameContext;
        }
        public void Exit()
        {
            gameContext.PlayerInputController.EnableMove(false);
        }

        public void Enter()
        {
            gameContext.LaunchBall.gameObject.SetActive(true);
            gameContext.PlayerInputController.EnableMove(true);
        }
    }
}