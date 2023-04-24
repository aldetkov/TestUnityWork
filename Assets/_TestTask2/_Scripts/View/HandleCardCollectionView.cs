using AxGrid;
using AxGrid.Base;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(CardPrefabPool))]
public class HandleCardCollectionView : MonoBehaviourExt
{
    [SerializeField] private Transform _containerHandleCardCollection;
    [Space]
    [SerializeField] private CardPrefab _cardPrefab;
    [Space]
    [SerializeField] private int _prefabPoolSize = 14;
    [SerializeField] private bool _autopool;

    private List<CardPrefab> _activeCardPrefabList;

    private CardPrefabPool _cardPrefabPool;

    private CardMover _cardMover;

    #region Mono

    [OnAwake]
    private void AwakeThis()
    {
        _cardPrefabPool = GetComponent<CardPrefabPool>();
        _cardMover = new();
        _activeCardPrefabList = new(_prefabPoolSize);
    }

    [OnStart]
    private void StartThis()
    {
        _cardPrefabPool.Initialize(_cardPrefab, _containerHandleCardCollection, _prefabPoolSize);

        Settings.Model.EventManager.AddAction(OnHandleCardCollectionEventChanged);
        Settings.Model.EventManager.AddAction(OnDropCardCollectionEventChanged);
    }

    [OnDestroy]
    private void OnDestroyThis()
    {
        Settings.Model.EventManager.RemoveAction(OnHandleCardCollectionEventChanged);
        Settings.Model.EventManager.RemoveAction(OnDropCardCollectionEventChanged);
    }

    #endregion

    #region Binds

    private void OnHandleCardCollectionEventChanged()
    {
        CardCollection<Card> handleCardCollection = Settings.Model.Get<CardCollection<Card>>(CardCollectionName.HandleCardCollection.ToString());
        Card card = handleCardCollection.GetLastCard();

        DrawCard(card);
    }

    private void OnDropCardCollectionEventChanged()
    {
        CardCollection<Card> dropCardCollection = Settings.Model.Get<CardCollection<Card>>(CardCollectionName.DropCardCollection.ToString());
        Card card = dropCardCollection.GetLastCard();

        RemovePrefabCard(card);
    }

    #endregion

    private void DrawCard(Card card)
    {
        CardPrefab firstCard = _cardPrefabPool.GetFirstAvailableCard();
        if (firstCard == null)
        {
            if (_autopool)
            {
                _cardPrefabPool.Initialize(_cardPrefab, _containerHandleCardCollection, _prefabPoolSize);
                DrawCard(card);
                return;
            }
            else
            {
                return;
            }
        }

        firstCard.Initialize(card);
        firstCard.Activate();

        _activeCardPrefabList.Add(firstCard);

        _cardMover.MoveAllCardPrefabsInList(_activeCardPrefabList, _containerHandleCardCollection);
    }

    private void RemovePrefabCard(Card card)
    {
        CardPrefab cardPrefab = _activeCardPrefabList.FirstOrDefault(item => item.Name == card.CardName);
        _activeCardPrefabList.Remove(cardPrefab);
        _cardMover.MoveAllCardPrefabsInList(_activeCardPrefabList, _containerHandleCardCollection);
    }
}