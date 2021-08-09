using Assets.PuzzleGame.Entity.Puzzles;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PuzzleGame.Entity.Puzzles
{
    public class Puzzle : MonoBehaviour, IDragHandler, IPointerUpHandler, IEndDragHandler
    {
        [SerializeField] private Canvas _canvas;

        private RectTransform _rectTransform;

        [SerializeField] private PuzzleNumber _puzzle;

        public PuzzleNumber PuzzleNumber => _puzzle;

        private CanvasGroup _canvasGroup;
        
        private Vector3 _startPos;

        private bool _isDrag = false;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _startPos = _rectTransform.position;
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (!_isDrag)
            {
                _isDrag = true;
                _startPos = _rectTransform.position;
            }

            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
            _canvasGroup.blocksRaycasts = false;
            _rectTransform.localScale = new Vector3(1, 1, 1);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<TruePuzzle>() == null)
            {
                ResetToStartPos();
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            _canvasGroup.blocksRaycasts = true;
            if (eventData.pointerCurrentRaycast.gameObject.GetComponent<TruePuzzle>() == null)
            {
                ResetToStartPos();
            }
        }

        public void ResetToStartPos()
        {
            _rectTransform.position = _startPos;
            _isDrag = false;
            if (_canvasGroup != null)
            {
                _canvasGroup.blocksRaycasts = true;
                _rectTransform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }
    }
}

public enum PuzzleNumber
{
    puzzle_1,
    puzzle_2,
    puzzle_3,
    puzzle_4
}