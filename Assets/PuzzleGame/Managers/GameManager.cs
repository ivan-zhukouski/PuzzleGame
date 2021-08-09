using System;
using GameStateMachine;
using PuzzleGame.GameStateMachine.StartGameState;
using PuzzleGame.GUI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace PuzzleGame.Managers
{
    public class GameManager: IInitializable, IDisposable
    {
        [Inject] private StateMachine _stateMachine;
        [Inject] private GuiHandler _gui;

        private Camera _cam;
        
        public void Initialize()
        {
            _gui.SetGuiState(GuiHandler.GuiState.Start);

            _stateMachine.Enter<StartState>();
            _gui.WinViewController.TryAgainEvent+= RestartGame;
        }

        public void Dispose()
        {
            _gui.WinViewController.TryAgainEvent-= RestartGame;
        }
        
        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}