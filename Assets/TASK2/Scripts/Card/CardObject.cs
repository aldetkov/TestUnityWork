using AxGrid;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CardTask
{
    [RequireComponent(typeof(RectTransform))]
    public class CardObject : BasePoolObject
    {
        [SerializeField] private string _name;

        [SerializeField] private Image _renderer;

        [SerializeField] private CardAnimateHandler _animateHandler;

        public  Card CurrentCard { get; private set; }

        public void Construct(string name, Sprite sprite)
        {
            _name = name;

            _renderer.sprite = sprite;
        }

        public void SetCurrentCard(Card card)
        {
            CurrentCard = card;
        }

        public void SetViewRect(RectTransform viewRect)
        {
            _animateHandler.SetUiRect(viewRect);
        }
    }

    public class Card
    {
        public string id;

        public string parentListName;

        public Card(string id, string parentListName)
        {
            this.id = id;

            this.parentListName = parentListName;
        }
    }
}
