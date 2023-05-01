using AxGrid.Base;
using AxGrid.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardTask
{
    public class CardViewHandler : MonoBehaviourExtBind
    {
        [SerializeField] private RectTransform _cardUserParent;

        [SerializeField] private RectTransform _cardTableParent;

        [SerializeField] private List<RectTransform> _cardUserCells;

        [SerializeField] private List<RectTransform> _cardTableCells;

        [Bind(EventKeys.OnAddCard)]
        private void AddElement(List<Card> userCollection)
        {
            try
            {
                var newUiElement = _cardUserCells.Find(t => !t.gameObject.activeSelf);

                newUiElement.gameObject.SetActive(true);

                Model.EventManager.Invoke(EventKeys.OnGetNewCard, userCollection.Last(), _cardUserParent, newUiElement);
            }

            catch (System.Exception)
            {
                throw new System.Exception("User have Max Cards");
            }

            Model.EventManager.Invoke(EventKeys.OnMoveCards);
        }

        [Bind(EventKeys.OnCardTranslate)]
        private void TranslateElement(Card translatedCard)
        {
            var newUiElement = _cardTableCells.Find(t => !t.gameObject.activeSelf);

            newUiElement.gameObject.SetActive(true);

            Model.EventManager.Invoke(EventKeys.OnSetTranslatedCard, translatedCard, _cardTableParent, newUiElement);

            Model.EventManager.Invoke(EventKeys.OnMoveCards);
        }
    }
}
