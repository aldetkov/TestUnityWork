using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
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


        [Bind(EventKeys.OnGetNewCard)]
        private void GetCard(Card card, RectTransform parent, RectTransform uiTransform)
        {
            var gettedCard = _poolsDict[card.id].GetObject() as CardObject;

            gettedCard.transform.SetParent(parent);

            gettedCard.SetCurrentCard(card);

            gettedCard.SetViewRect(uiTransform);

            _existingCards.Add(card, gettedCard);
        }

        [Bind(EventKeys.OnSetTranslatedCard)]
        private void TranslateCard(Card card, RectTransform parent, RectTransform uiTransform)
        {
            var translatedCard = _existingCards[card];

            translatedCard.transform.SetParent(parent);

            translatedCard.SetViewRect(uiTransform);
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