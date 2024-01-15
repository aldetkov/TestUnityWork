using AxGrid.Base;
using System.Collections.Generic;
using UnityEngine;

namespace CardTask
{
    public class CardObjectHandler : MonoBehaviourExtBind
    {
        [SerializeField] private Transform _cardParent;

        [SerializeField] private CardData[] _cardDatas;

        [SerializeField] private CardObject _cardPrefab;

        private Dictionary <Card, CardObject> _existingCards;

        private Dictionary<string, CardPool<BasePoolObject>> _poolsDict;

        private Dictionary<string, CardFactory> _factoryDict;

        [OnAwake]
        private void AwakeThis()
        {
            _poolsDict = new Dictionary<string, CardPool<BasePoolObject>>();

            _factoryDict = new Dictionary<string, CardFactory>();

            _existingCards = new Dictionary<Card, CardObject>();

            for (int i = 0; i < _cardDatas.Length; i++)
            {
                var currentFactory = new CardFactory(_cardPrefab, _cardParent, _cardDatas[i]);

                _factoryDict.Add(_cardDatas[i].id, currentFactory);

                _poolsDict.Add(_cardDatas[i].id, new CardPool<BasePoolObject>(currentFactory, _cardParent));
            }
        }

        public CardObject GetCard(Card card)
        {
            var gettedCard = _poolsDict[card.id].GetObject() as CardObject;

            gettedCard.SetCurrentCard(card);

            _existingCards.Add(card, gettedCard);

            gettedCard.transform.SetParent(transform);

            return gettedCard;
        }

        public void TranslateCard(Card card, RectTransform parent, RectTransform uiTransform)
        {
            var translatedCard = _existingCards[card];

            translatedCard.transform.SetParent(parent);

            translatedCard.SetViewRect(uiTransform);
        }

        public void RemoveCard(Card card)
        {
            _poolsDict[card.id].ReturnObject(_existingCards[card]);
        }
    }

    [System.Serializable]
    public class CardData
    {
        public string id;

        public string cardName;

        public Sprite cardSprite;
    }
}