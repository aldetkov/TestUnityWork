using AxGrid;
using System.Collections.Generic;

public class CardCollection<T> where T : Card
{
    public List<T> CardList { get; }

    private readonly CardCollectionName _name;
    private readonly CardCollectionEventName _eventName;

    public CardCollection(int collectionStartSize, CardCollectionName name, CardCollectionEventName eventName)
    {
        CardList = new List<T>(collectionStartSize);
        _name = name;
        _eventName = eventName;

        Settings.Model.SilentSet(_name.ToString(), this);
    }

    public Card GetLastCard()
    {
        if (!HasLastCard()) return null;

        return CardList[^1];
    }

    public T GetCardByCardPrefab(CardPrefab cardPrefab)
    {
        foreach (var item in CardList)
            if (item.CardName == cardPrefab.Name)
                return item;

        return null;
    }

    public void Add(T item)
    {
        CardList.Add(item);
        Settings.Model.Inc(_eventName.ToString());
    }

    public void Remove(T item)
    {
        if (!CanRemove(item)) return;

        CardList.Remove(item);
    }

    public void Remove(int index)
    {
        if (!CanRemove(index)) return;

        CardList.RemoveAt(index);
    }

    private bool CanRemove(int index) => CardList.Count > index;
    private bool CanRemove(T item) => CardList.Contains(item);
    private bool HasLastCard() => CardList.Count > 0;
}