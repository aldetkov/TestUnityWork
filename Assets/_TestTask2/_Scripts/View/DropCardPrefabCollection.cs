using AxGrid;
using AxGrid.Base;
using System.Collections.Generic;
using UnityEngine;

public class DropCardPrefabCollection : MonoBehaviourExt
{
    [SerializeField] private Transform _containerDropCardCollection;

    private List<CardPrefab> _cardPrefabList;

    private CardMover _cardMover;

    private int _cardPrefabCounter;

    private readonly float _offsetX = -0.5f;

    #region Mono

    [OnAwake]
    private void AwakeThis()
    {
        _cardPrefabList = new();
        _cardMover = new CardMover();
    }

    [OnStart]
    private void StartThis()
    {
        Settings.Model.EventManager.AddAction(OnDropCardCollectionEventChanged);
    }

    [OnDestroy]
    private void OnDestroyThis()
    {
        Settings.Model.EventManager.RemoveAction(OnDropCardCollectionEventChanged);
    }

    #endregion

    #region Binds

    private void OnDropCardCollectionEventChanged()
    {
        CardPrefab cardPrefab = Settings.Model.Get<CardPrefab>(Prefab.CardPrefab.ToString());

        MovePrefabCardToDropContainer(cardPrefab);
    }

    #endregion
    private void MovePrefabCardToDropContainer(CardPrefab cardPrefab)
    {
        MoveNewCard(cardPrefab);
        MoveCardPrefabListWithoutNewPrefab(cardPrefab);
    }

    private void MoveNewCard(CardPrefab cardPrefab)
    {
        cardPrefab.transform.SetParent(_containerDropCardCollection, true);
        _cardPrefabCounter++;
        int queue = _cardPrefabCounter - _cardPrefabList.Count - 1;
        _cardMover.MoveNewCardPrefab(_cardPrefabList, cardPrefab, queue, _containerDropCardCollection, _offsetX);
    }

    private void MoveCardPrefabListWithoutNewPrefab(CardPrefab cardPrefab)
    {
        _cardPrefabList.Add(cardPrefab);
        int indexNewCardPrefab = _cardPrefabList.IndexOf(cardPrefab);
        _cardMover.MoveCardPrefabsInListWithoutNewCard(_cardPrefabList, indexNewCardPrefab, _containerDropCardCollection);
    }
}
