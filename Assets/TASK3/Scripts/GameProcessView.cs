using AxGrid.Base;
using AxGrid.Model;
using AxGrid.Path;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameProcessView : MonoBehaviourExtBind
{
    [SerializeField] private List<Color> _gameColors;

    [SerializeField] private Image _bg;

    [OnStart]
    private void OnStartThis()
    {
        SetGame(false);
    }

    [Bind("IsGame")]
    private void SetGame(bool value)
    {
        gameObject.SetActive(value);
    }


    [Bind("OnGameProcessChange")]
    private void GameProcess(bool value)
    {
        if (!value)
        {
            Path.StopPath();
            return;
        }

        var targetColor = _gameColors[Random.Range(0, _gameColors.Count)];

        Path.
            EasingLinear(0.5f, 0, 1, (f) => _bg.color = Color.Lerp(_bg.color, targetColor, f)).
            Action(()=> GameProcess(value));
    }
}
