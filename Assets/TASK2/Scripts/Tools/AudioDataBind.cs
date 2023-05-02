using AxGrid;
using AxGrid.Base;
using AxGrid.Model;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDataBind : MonoBehaviourExtBind
{
    public string[] fieldNames = new string[0];

    [SerializeField] protected string soundName = "";

    [SerializeField] protected string enableField = "";

    [SerializeField] protected string volumeField = "";

    [SerializeField] protected string loopField = "";

    [SerializeField] protected bool defaultEnable = true;

    [SerializeField] protected bool defaultLoop = false;

    [SerializeField] protected float defaultVolume = 1;

    protected AudioSource source;

    [OnAwake]
    private void AwakeThis()
    {
        source = GetComponent<AudioSource>();

        if (string.IsNullOrEmpty(soundName))
        {
            soundName = name;
            Log.Warn($"Button name is empty {source.name}");
        }

        if (source.clip == null)
        {
            Log.Warn($"Sorce clip is empty {source.name}");
        }

        enableField = enableField == "" ? $"Sound{soundName}Enable" : enableField;

        volumeField = volumeField == "" ? $"SoundVolume{soundName}Enable" : volumeField;

        loopField = loopField == "" ? $"SoundLoop{soundName}Enable" : loopField;
    }

    [OnStart]
    public void start()
    {
        Model.EventManager.AddAction($"On{enableField}Changed", OnItemEnable);
        Model.EventManager.AddAction($"On{volumeField}Changed", OnSetVolume);
        Model.EventManager.AddAction($"On{loopField}Changed", OnSetLoop);

        foreach (var fieldName in fieldNames)
            Model.EventManager.AddAction($"On{fieldName}Changed", PlaySound);

        OnItemEnable();
        OnSetLoop();
        OnSetVolume();
    }

    protected void OnItemEnable()
    {
        if (source.enabled != Model.GetBool(enableField, defaultEnable))
            source.enabled = Model.GetBool(enableField, defaultEnable);
    }

    protected void OnSetLoop()
    {
        if (source.loop != Model.GetBool(loopField, defaultLoop))
            source.loop = Model.GetBool(loopField, defaultLoop);
    }

    protected void OnSetVolume()
    {
        if (source.volume != Model.GetFloat(volumeField, defaultVolume))
            source.volume = Model.GetFloat(volumeField, defaultVolume);
    }

    [Bind("On{soundName}Play")]
    protected virtual void PlaySound()
    {
        source.Play();
    }

    [OnDestroy]
    public void onDestroy()
    {
        Model.EventManager.RemoveAction($"On{enableField}Changed", OnItemEnable);
        Model.EventManager.RemoveAction($"On{volumeField}Changed", OnSetVolume);
        Model.EventManager.RemoveAction($"On{loopField}Changed", OnSetLoop);
    }
}
