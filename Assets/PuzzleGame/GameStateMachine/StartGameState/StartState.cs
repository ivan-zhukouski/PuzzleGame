using PuzzleGame.GUI;
using UnityEngine;
using Zenject;

namespace PuzzleGame.GameStateMachine.StartGameState
{
    public class StartState : IState
    {
        [Inject] private GuiHandler _guiHandler;

        public void Enter()
        {
            if (!PlayerPrefs.HasKey("CurrLevel"))
            {
                PlayerPrefs.SetInt("CurrLevel", 1);
            }
            ActiveStartPanel();
            
            PlayerPrefs.SetInt("CountLevel", PlayerPrefs.GetInt("CountLevel") + 1);
        }

        private void ActiveStartPanel()
        {
            if (_guiHandler != null)
            {
                _guiHandler.SetGuiState(GuiHandler.GuiState.Start);
            }
        }

        public void Exit()
        {
            
        }
    }
}