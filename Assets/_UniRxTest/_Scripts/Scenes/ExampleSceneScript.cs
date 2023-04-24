using System;
using UniRx;
using UnityEngine;

public class ExampleSceneScript : MonoBehaviour
{
    [SerializeField] private float _timeToLoadTargetScene = 3f;
    [SerializeField] private SceneName _targetSceneName;

    private readonly string _failedLoadString = "Failed to load scene: ";
    private readonly CompositeDisposable _disposable = new();

    #region Mono

    private void Start()
    {
        Observable.Timer(TimeSpan.FromSeconds(_timeToLoadTargetScene))
            .Subscribe(
                _ => { SceneLoader.LoadTargetScene(_targetSceneName); },
                error => Debug.LogError(_failedLoadString + error.Message),
                () => _disposable.Clear())
            .AddTo(_disposable);
    }

    private void OnDestroy()
    {
        _disposable.Clear();
    }

    #endregion
}
