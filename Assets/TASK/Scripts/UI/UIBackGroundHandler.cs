using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using UnityEngine;
using UnityEngine.UI;

public class UIBackGroundHandler : MonoBehaviourExtBind
{
    [SerializeField] private Color _workColor;
    [SerializeField] private Color _homeColor;
    [SerializeField] private Color _storeColor;

    [SerializeField] private Image Bg;

    [SerializeField] private float _colorChangeDuration = 1;

    [OnAwake]
    private void OnAwakeThis()
    {
        Model.Set(StateKeys.homeState, _homeColor);
        Model.Set(StateKeys.storeState, _storeColor);
        Model.Set(StateKeys.workState, _workColor);
    }

    [Bind(EventKeys.workerNextPlace)]
    private void OnChangeColor(string targetState)
    {
        //var targetState = Model.GetString(ModelKeys.targetState);
        var targetColor = (Color)Model.Get(targetState);

        Path.EasingLinear(_colorChangeDuration, 0, 1, (f) => Bg.color = Color.Lerp(Bg.color, targetColor, f / 2));
    }
}
