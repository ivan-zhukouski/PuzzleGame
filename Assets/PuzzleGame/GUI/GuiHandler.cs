using System;
using GameStateMachine;
using PuzzleGame.GUI.GamePanel;
using PuzzleGame.GUI.StartPanel;
using PuzzleGame.GUI.WinPanel;
using UnityEngine;
using Zenject;

namespace PuzzleGame.GUI
{
    public class GuiHandler : MonoBehaviour
    {
        [Inject] private CallBackState _callBackState;
        public enum GuiState
        {
            Start,
            Game, 
            Win,
        }
        
        public int TruePuzzlesCount = 0;

        public StartViewController StartViewController;
        public GameViewController GameViewController;
        public WinViewController WinViewController;

        public void CheckAllPicture()
        {
            if (TruePuzzlesCount >= Enum.GetNames(typeof(PuzzleNumber)).Length)
            {
                _callBackState.EnterWinState();
            }
        }
        
        public void SetGuiState(GuiState state)
        {
            switch (state)
            {
                case GuiState.Start:
                    StartViewController.gameObject.SetActive(true);
                    GameViewController.gameObject.SetActive(false);
                    WinViewController.gameObject.SetActive(false);
                    break;
                case GuiState.Game:
                    StartViewController.gameObject.SetActive(false);
                    GameViewController.gameObject.SetActive(true);
                    WinViewController.gameObject.SetActive(false);
                    break;
                case GuiState.Win:
                    StartViewController.gameObject.SetActive(false);
                    GameViewController.gameObject.SetActive(true);
                    WinViewController.gameObject.SetActive(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(state), state, null);
            }
        }
    }
}
