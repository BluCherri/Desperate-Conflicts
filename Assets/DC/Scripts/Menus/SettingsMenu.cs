using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField]
    private AudioMixer m_MainMixer;

    [SerializeField]
    private string m_MusicMixerVar = "MusicVol";

    [SerializeField]
    private string m_SFXMixerVar = "SFXVol";

    [SerializeField]
    private TMP_Dropdown m_GraphicsQualityDropdown;

    [SerializeField]
    private TMP_Dropdown m_ResolutionDropdown;

    [SerializeField]
    private Toggle m_FullscreenToggle;

    private Resolution[] m_Resolutions;

    [SerializeField]
    private GameObject m_DisplayOptions = null;

    private void Start()
    {
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
        m_DisplayOptions.SetActive(false);
#endif

        m_GraphicsQualityDropdown.value = QualitySettings.GetQualityLevel();
        m_GraphicsQualityDropdown.RefreshShownValue();

        m_FullscreenToggle.isOn = Screen.fullScreen;

        m_Resolutions = Screen.resolutions;

        m_ResolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < m_Resolutions.Length; i++)
        {
            string option = $"{m_Resolutions[i].width} x {m_Resolutions[i].height} {m_Resolutions[i].refreshRate}Hz";
            options.Add(option);
            if (m_Resolutions[i].width == Screen.currentResolution.width && m_Resolutions[i].height == Screen.currentResolution.height && m_Resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                currentResolutionIndex = i;
            }
        }

        m_ResolutionDropdown.AddOptions(options);
        m_ResolutionDropdown.value = currentResolutionIndex;
        m_ResolutionDropdown.RefreshShownValue();
    }

    public void SetMusicVolume(float vol)
    {
        m_MainMixer.SetFloat(m_MusicMixerVar, vol);
    }

    public void SetSFXVolume(float vol)
    {
        m_MainMixer.SetFloat(m_SFXMixerVar, vol);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int index)
    {
        Resolution res = m_Resolutions[index];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
