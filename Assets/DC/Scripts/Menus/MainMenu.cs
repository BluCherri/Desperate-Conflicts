using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string m_FeedbackURL = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

    [SerializeField]
#pragma warning disable CS0414
    private Button m_ExitButton = null;
#pragma warning restore CS0414

    private void Start()
    {
#if UNITY_WEBGL || UNITY_ANDROID || UNITY_IOS
        m_ExitButton.gameObject.SetActive(false);
#endif
    }

    public void OnPlayButtonClicked()
    {
        SceneLoader.Load(SCENES.MAP01);
    }

    public void OnCreditsButtonClicked()
    {

    }

    public void OnExitButtonClicked()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void OnFeedbackButtonClicked()
    {
        Application.OpenURL(m_FeedbackURL);
    }
}
