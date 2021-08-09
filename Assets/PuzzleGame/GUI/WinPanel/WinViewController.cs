using System;
using Assets.PuzzleGame.GUI.WinPanel;
using UnityEngine;

namespace PuzzleGame.GUI.WinPanel
{
    [RequireComponent(typeof(WinView))]
    public class WinViewController : MonoBehaviour
    {
        public WinView View => GetComponent<WinView>();

        public event Action TryAgainEvent;


        private void OnEnable()
        {
            View.LightBackground.SetActive(true);
            View.PuzzlesPanel.SetActive(false);
            View.TryAgain.gameObject.SetActive(true);
            View.TryAgain.onClick.AddListener(OnNextLevelBtnClick);
        }

        private void OnDisable()
        {
            View.TryAgain.onClick.RemoveListener(OnNextLevelBtnClick);
        }

        private void OnNextLevelBtnClick()
        {
            TryAgainEvent?.Invoke();
        }
    }
}