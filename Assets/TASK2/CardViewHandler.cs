using AxGrid.Base;
using AxGrid.Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CardTask
{
    public class CardViewHandler : MonoBehaviourExtBind
    {
        [SerializeField] private CardObjectHandler _cardObjects;

        [SerializeField] private List<TablePlace> _tablePlaces;

        [Bind(EventKeys.OnAddCard)]
        private void AddNewElement(List<Card> collection)
        {
            var currentCard = collection.Last();

            var newCardObject = _cardObjects.GetCard(currentCard);

            var targetPlace = _tablePlaces.Find(p => p.placeId == currentCard.parentListName);

            var emptyCell = GetEmtyCell(targetPlace.cardCells);

            newCardObject.transform.SetParent(targetPlace.cardParent);

            newCardObject.SetViewRect(emptyCell);

            Model.EventManager.Invoke(EventKeys.OnMoveCards);
        }

        [Bind(EventKeys.OnRemoveCard)]
        private void RemoveElement(Card removedCard)
        {
            _cardObjects.RemoveCard(removedCard);
        }

        [Bind(EventKeys.OnTranslateCard)]
        private void TranslateElement(Card translatedCard)
        {
            var targetPlace = _tablePlaces.Find(p => p.placeId == translatedCard.parentListName);

            var emptyCell = GetEmtyCell(targetPlace.cardCells);

            _cardObjects.TranslateCard(translatedCard, targetPlace.cardParent, emptyCell);

            Model.EventManager.Invoke(EventKeys.OnMoveCards);
        }

        private RectTransform GetEmtyCell(List<RectTransform> targetPlace)
        {
            try
            {
                var newUiElement = targetPlace.Find(t => !t.gameObject.activeSelf);

                newUiElement.SetSiblingIndex(0);

                newUiElement.gameObject.SetActive(true);

                return newUiElement;
            }

            catch (System.Exception)
            {
                Debug.Log("Place is full");

                return null;
            }
        }

        [System.Serializable]
        public class TablePlace
        {
            public string placeId;

            public RectTransform cardParent;

            public List<RectTransform> cardCells;
        }
    }
}
