using System.Collections.Generic;
using UnityEngine;

public class CardMover
{
    private readonly float _distanceBetweenCards = 1f;

    public void MoveAllCardPrefabsInList(List<CardPrefab> cardPrefabList, Transform container, float offsetX = 0)
    {
        for (int i = 0; i < cardPrefabList.Count; i++)
            cardPrefabList[i].MoveToPosition(GetTargerPosition(cardPrefabList, container, i, offsetX));
    }

    public void MoveCardPrefabsInListWithoutNewCard(List<CardPrefab> cardPrefabList, int cardIndex, Transform container, float offsetX = 0)
    {
        for (int i = 0; i < cardPrefabList.Count; i++)
        {
            if (i == cardIndex)
                continue;

            cardPrefabList[i].MoveToPosition(GetTargerPosition(cardPrefabList, container, i, offsetX));
        }
    }

    public void MoveNewCardPrefab(List<CardPrefab> cardPrefabList, CardPrefab cardPrefab, int queue, Transform container, float offsetX = 0)
    {
        int cardPrefabIndex = cardPrefabList.Count + queue;

        cardPrefab.MoveToPosition(GetTargerPosition(cardPrefabList, container, cardPrefab, cardPrefabIndex, offsetX));
    }

    #region Calulation

    private Vector3 GetTargerPosition(List<CardPrefab> cardPrefabList, Transform container, int index, float offsetX)
    {
        Vector3 targetPosition = new(GetCardPrefabPosX(GetCollectionCenterX(cardPrefabList), index, offsetX),
            cardPrefabList[index].GetOffsetY(container), index);

        return targetPosition;
    }

    private Vector3 GetTargerPosition(List<CardPrefab> cardPrefabList, Transform container, CardPrefab cardPrefab, int i, float offsetX)
    {
        Vector3 targetPosition = new(GetCardPrefabPosX(GetCollectionCenterX(cardPrefabList), i, offsetX),
            cardPrefab.GetOffsetY(container), i);

        return targetPosition;
    }

    private float GetCardPrefabPosX(float centerX, float i, float offsetX)
    {
        return i * _distanceBetweenCards - centerX + offsetX;
    }

    private float GetCollectionCenterX(List<CardPrefab> cardPrefabList)
    {
        return (cardPrefabList.Count - 1) / 2f * _distanceBetweenCards;
    }

    #endregion
}
