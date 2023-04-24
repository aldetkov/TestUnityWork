using AxGrid;
using AxGrid.Base;
using AxGrid.Tools.Binders;
using UnityEngine;
using AxGrid.Path;
using Random = UnityEngine.Random;

public class CardPrefab : MonoBehaviourExt
{
    [SerializeField] private UITextMPDataBind _uITextMPDataBind;
    [SerializeField] private float _timeAnimation = 0.5f;
    [SerializeField] private float _maxValue = 0.5f;

    public string Name { get; private set; }

    private readonly float _cardOffsetY = 0.07f;

    private readonly float _minValue = 0;

    private bool _isDropped;

    #region Mono

    private void OnMouseDown()
    {
        if (_isDropped)
            return;

        Settings.Model.Set(Prefab.CardPrefab.ToString(), this);
        _isDropped = true;
    }

    #endregion

    public bool IsAvailable()
    {
        return !gameObject.activeInHierarchy;
    }
    public void Initialize(Card card)
    {
        _uITextMPDataBind.format = Name = card.CardName;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public float GetOffsetY(Transform container)
    {
        return container.position.y + Random.Range(-_cardOffsetY, _cardOffsetY);
    }

    public void MoveToPosition(Vector3 targetPosition)
    {
        Path = new CPath();

        Path.EasingLinear(_timeAnimation, _minValue, _maxValue, value =>
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, value);
        });
    }
}