using CodeHub.StateMachine;

namespace Game.Scripts.Game.CoreGame.Infrastructure
{
    public class EndGameState : IState
    {
        private readonly GameStateMachine gameStateMachine;
        private readonly GameContext gameContext;

        public EndGameState(GameStateMachine gameStateMachine, GameContext gameContext)
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
            gameContext.PlayerInputController.EnableMove(false);
            gameContext.BallThrower.GameLine.EnableDraw(false);

            gameContext.GameOverContext.CheckBestGoalsCount();
            gameContext.GameOverContext.GetReward();
            gameContext.GameOverContext.AddGameOverPanel();

            gameContext.AudioContext.PlayWinGame();

            gameContext.BallsParent.gameObject.SetActive(false);
        }
    }
}