using AxGrid.Base;
using AxGrid.Path;
using UnityEngine;

namespace CardTask
{
    public class CardAnimateHandler : MonoBehaviourExtBind
    {
        [SerializeField] private RectTransform _selfRect;

        private RectTransform _UiRect;

        private const float TranslateCardDuration = 0.2f;

        public void SetUiRect(RectTransform uiRect)
        {
            if (_UiRect != null)
                _UiRect.gameObject.SetActive(false);

            _UiRect = uiRect;

            Model.EventManager.AddAction(EventKeys.OnMoveCards, MoveCard);
        }

        private void MoveCard()
        {
            Path.EasingCircEaseIn
              (TranslateCardDuration, 0, 1, (f) => _selfRect.anchoredPosition = 
              Vector3.Lerp(_selfRect.anchoredPosition, _UiRect.anchoredPosition, f));
        }
    }
}
