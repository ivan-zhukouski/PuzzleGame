using PuzzleGame.GameStateMachine.PlayGameState;
using PuzzleGame.GameStateMachine.StartGameState;
using PuzzleGame.GameStateMachine.WinGameState;
using Zenject;

namespace GameStateMachine
{
    public class CallBackState
    {
        private StateMachine _stateMachine;

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void EnterPlayState()
        {
            _stateMachine.Enter<PlayState>();
        }

        public void EnterWinState()
        {
            _stateMachine.Enter<WinState>();
        }
        public void EnterMenuEvent()
        {
            _stateMachine.Enter<StartState>();
        }
    }
}
