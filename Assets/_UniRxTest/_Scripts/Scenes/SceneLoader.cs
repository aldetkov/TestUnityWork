using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Slider _progressBar;
    [SerializeField] private TextMeshProUGUI _progressText;

    private static SceneName s_targetScene = SceneName.SceneToLoad1;


    #region Mono

    private void Start()
    {
        StartLoadScene(s_targetScene);
    }

    #endregion

    public static void LoadTargetScene(SceneName sceneName)
    {
        s_targetScene = sceneName;
        SceneManager.LoadSceneAsync(SceneName.SceneLoading.ToString(), LoadSceneMode.Single);
    }

    private void StartLoadScene(SceneName sceneName)
    {
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName.ToString());
        scene.allowSceneActivation = false;
        IProgress<float> progress = GetFloatProgress();

        UpdateProgress(scene, progress);
    }

    private void UpdateProgress(AsyncOperation scene, IProgress<float> progress)
    {
        CompositeDisposable loaderDisposable = new();

        Observable.EveryUpdate()
            .TakeWhile(_ => scene.progress < 0.9f)
            .Select(_ => scene.progress / 0.9f)
            .Subscribe(sceneProgress =>
            {
                Debug.Log(sceneProgress);
                progress.Report(sceneProgress);
            },
            () =>
            {
                Observable.Timer(TimeSpan.FromSeconds(1f))
                    .Subscribe(_ =>
                    {
                        progress.Report(1f);
                        scene.allowSceneActivation = true;
                    },
                    () => { loaderDisposable.Clear(); }).AddTo(loaderDisposable);
            }).AddTo(loaderDisposable);
    }

    private IProgress<float> GetFloatProgress()
    {
        return new Progress<float>(value =>
        {
            _progressBar.value = value;
            _progressText.text = $"Loading {value:P0}";
        });
    }
}
