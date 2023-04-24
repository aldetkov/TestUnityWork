using System;
using Random = UnityEngine.Random;

[Serializable]
public class Card
{
    public int Value;
    public string CardName;
    public string SpriteName;

    public Card(int maxIndex)
    {
        CardName = GetRandomCardName(maxIndex);
    }

    public Card(string cardName)
    {
        CardName = cardName;
    }

    private string GetRandomCardName(int maxIndex)
    {
        return $"Card{Random.Range(0, maxIndex)}";
    }
}