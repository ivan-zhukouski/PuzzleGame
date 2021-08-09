using PuzzleGame.Entity.Puzzles;
using PuzzleGame.GUI;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Assets.PuzzleGame.Entity.Puzzles
{
    public class TruePuzzle : MonoBehaviour,IDropHandler
    {
        [SerializeField]
        private PuzzleNumber _puzzleNumber;

        [Inject] private GuiHandler _guiHandler;

        [SerializeField] private RectTransform _parentTrans;
        
        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                Puzzle puzzle = eventData.pointerDrag.GetComponent<Puzzle>();
                if (puzzle!=null && _puzzleNumber == puzzle.PuzzleNumber)
                {
                    RectTransform puzzleTransform = eventData.pointerDrag.GetComponent<RectTransform>();
                    RectTransform slotTransform = GetComponent<RectTransform>();
                    puzzleTransform.position = slotTransform.position;
                    puzzle.enabled = false;
                    puzzle.transform.parent = gameObject.transform;
                    
                    _guiHandler.TruePuzzlesCount++;
                    _guiHandler.CheckAllPicture();
                }
                else
                {
                    puzzle.ResetToStartPos();
                }
            }
        }
    }
}
