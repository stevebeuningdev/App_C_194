using CodeHub.StateMachine;
using UnityEngine;

namespace Game.Scripts.Game.CoreGame.Infrastructure
{
    public class GameStateMachine : AbstractStateMachine
    {
        public GameStateMachine(GameContext gameContext)
        {
            States[typeof(StartState)] = new StartState(this, gameContext);
            States[typeof(ThrowBallState)] = new ThrowBallState(this, gameContext);
            States[typeof(EndGameState)] = new EndGameState(this, gameContext);
        }
    }
}