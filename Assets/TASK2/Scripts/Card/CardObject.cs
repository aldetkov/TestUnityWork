using AxGrid;
using AxGrid.FSM;
using CardTask;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CardObject : BasePoolObject, IPointerClickHandler
{
    [SerializeField] private string _name;

    [SerializeField] private Image _renderer;

    [SerializeField] private CardAnimateHandler _animateHandler;

    private Card _currentCard;

    public void Construct(string name, Sprite sprite)
    {
        _name = name;

        _renderer.sprite = sprite;
    }

    public void SetCurrentCard(Card card)
    {
        _currentCard = card;
    }

    public void SetViewRect(RectTransform viewRect)
    {
        _animateHandler.SetUiRect(viewRect);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Settings.Model.Set(ModelKeys.translatedCard, _currentCard);

        Settings.Fsm.Invoke(EventKeys.OnCardClick);
    }
}

public class Card
{
    public string id;

    public Card(string id)
    {
        this.id = id;
    }
}
