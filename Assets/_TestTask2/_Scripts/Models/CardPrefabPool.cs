using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardPrefabPool : MonoBehaviour
{
    private List<CardPrefab> _cardPrefabPoolList;
    private readonly string _descriptionExceptionInitialize = "CardPrefabPool isn't initialized";

    public void Initialize(CardPrefab cardPrefab, Transform container, int initializeSize)
    {
        _cardPrefabPoolList ??= new List<CardPrefab>(initializeSize);

        _cardPrefabPoolList = Enumerable.Range(0, initializeSize)
            .Select(i =>
            {
                CardPrefab createdCardPrefab = Instantiate(cardPrefab, container);
                createdCardPrefab.Deactivate();
                return createdCardPrefab;
            })
            .ToList();
    }

    public List<CardPrefab> GetCardPrefabPool()
    {
        if (_cardPrefabPoolList == null)
            throw new ArgumentNullException(_descriptionExceptionInitialize);

        return _cardPrefabPoolList;
    }

    public CardPrefab GetFirstAvailableCard()
    {
        return _cardPrefabPoolList.FirstOrDefault(x => x.IsAvailable());
    }
}
