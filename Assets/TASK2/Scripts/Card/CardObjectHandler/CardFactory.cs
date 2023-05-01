using CardTask;
using UnityEngine;

public class CardFactory : BaseMonoFactory<CardObject>
{
    private CardData _data;

    public CardFactory(CardObject prefab, Transform container, CardData data) : base(prefab, container)
    {
        _data = data;
    }
    public override CardObject CreateObject()
    {
        var newCard =  base.CreateObject();

        newCard.Construct(_data.cardName, _data.cardSprite);

        return newCard;
    }
}


