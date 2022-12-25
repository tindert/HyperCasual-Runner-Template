using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    Toggle musicToggle;

    [SerializeField]
    Toggle hapticToggle;

    [SerializeField]
    Toggle SFXToggle;

    private void Awake()
    {
        musicToggle.onValueChanged.AddListener(OnMusicChanged);
        hapticToggle.onValueChanged.AddListener(OnHapticChanged);
        SFXToggle.onValueChanged.AddListener(OnSFXChanged);

        if (musicToggle)
            OnMusicChanged(true);
        if (hapticToggle)
            OnHapticChanged(true);
        if (SFXToggle)
            OnSFXChanged(true);
    }

    void OnMusicChanged(bool on)
    {
        if (on)
        {
            Debug.Log("Music" + on);
        }
        else
        {
            Debug.Log("Music" + on);
        }
    }

    void OnHapticChanged(bool on)
    {
        if (on)
        {
            Debug.Log("Haptic" + on);
        }
        else
        {
            Debug.Log("Haptic" + on);
        }
    }

    void OnSFXChanged(bool on)
    {
        if (on)
        {
            Debug.Log("SFX" + on);
        }
        else
        {
            Debug.Log("SFX" + on);
        }
    }
}
