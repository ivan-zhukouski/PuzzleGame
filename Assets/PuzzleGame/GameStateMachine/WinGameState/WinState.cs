using PuzzleGame.GameStateMachine.StartGameState;
using PuzzleGame.GUI;
using Zenject;

namespace PuzzleGame.GameStateMachine.WinGameState
{
    public class WinState: IState
    {
        private GuiHandler _guiHandler;

        [Inject]
        private void Construct(GuiHandler guiHandler)
        {
            _guiHandler = guiHandler;
        }

        public void Enter()
        {
            ActiveWinPanel();
        }

        private void ActiveWinPanel()
        {
            if (_guiHandler != null)
            {
                _guiHandler.SetGuiState(GuiHandler.GuiState.Win);
            }
        }

        public void Exit()
        {
            
        }
    }
}