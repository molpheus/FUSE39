using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController I { get; private set; }
    public enum BGM
    {
        Main,
    }

    public enum SE
    {
        Ok,
        Catch,
        Select,
    }

    public enum SFX
    {
        Propeller,
    }

    private const float _maxVolume = 0;
    private const float _minVolume = -80;

    [SerializeField]
    private AudioMixer _audioMixer;

    [SerializeField]
    private AudioSource _bgmSource;

    [SerializeField]
    private AudioSource _seSource;

    [SerializeField]
    private AudioSource _sfxSource;

    public float BgmVolume
    {
        get
        {
            _audioMixer.GetFloat("BGMVolume", out var volume);
            return Mathf.Abs(volume) / Mathf.Abs(_minVolume);
        }
        set => _audioMixer.SetFloat("BGMVolume", Mathf.Lerp(_minVolume, _maxVolume, Mathf.Clamp01(value)));
    }

    public float SeVolume
    {
        get
        {
            _audioMixer.GetFloat("SEVolume", out var volume);
            return Mathf.Abs(volume) / Mathf.Abs(_minVolume);
        }
        set => _audioMixer.SetFloat("SEVolume", Mathf.Lerp(_minVolume, _maxVolume, Mathf.Clamp01(value)));
    }

    public float SfxVolume
    {
        get
        {
            _audioMixer.GetFloat("SFXVolume", out var volume);
            return Mathf.Abs(volume) / Mathf.Abs(_minVolume);
        }
        set => _audioMixer.SetFloat("SFXVolume", Mathf.Lerp(_minVolume, _maxVolume, Mathf.Clamp01(value)));
    }

    [SerializeField]
    private AudioClip[] _bgmClips;

    [SerializeField]
    private AudioClip[] _seClips;

    [SerializeField]
    private AudioClip[] _sfxClips;

    private void Awake()
    {
        if (I == null)
        {
            I = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (I == this)
        {
            I = null;
        }
    }


    public void PlayBGM(BGM tag)
    {
        _bgmSource.Stop();
        _bgmSource.clip = _bgmClips[(int)tag];
        _bgmSource.Play();
    }

    public void PlaySE(SE tag)
    {
        _seSource.Stop();
        _seSource.clip = _seClips[(int)tag];
        _seSource.Play();
    }

    public void PlaySFX(SFX tag)
    {
        _sfxSource.Stop();
        _sfxSource.clip = _sfxClips[(int)tag];
        _sfxSource.Play();
    }

    public void StopBGM()
        => _bgmSource.Stop();

    public void StopSE()
        => _seSource.Stop();

    public void StopSFX()
        => _sfxSource.Stop();

#if false
    private void OnGUI()
    {
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.Label("BGM");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Main"))
        {
            PlayBGM(BGM.Main);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label($"BgmVolume");
        BgmVolume = GUILayout.HorizontalSlider(BgmVolume, 0, 1);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("SE");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("OK"))
        {
            PlaySE(SE.Ok);
        }
        if (GUILayout.Button("Catch"))
        {
            PlaySE(SE.Catch);
        }
        if (GUILayout.Button("Select"))
        {
            PlaySE(SE.Select);
        }
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label($"SeVolume");
        SeVolume = GUILayout.HorizontalSlider(SeVolume, 0, 1);
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        GUILayout.Label("SFX");
        GUILayout.EndHorizontal();
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Propeller"))
        {
            PlaySFX(SFX.Propeller);
        }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label($"SfxVolume");
        SfxVolume = GUILayout.HorizontalSlider(SfxVolume, 0, 1);
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
    }
#endif
}
