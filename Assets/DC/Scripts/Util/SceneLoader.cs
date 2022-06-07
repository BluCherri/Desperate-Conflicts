using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private static bool m_Transitioning = false;

    public static void RegisterCallbacks()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public static void OnSceneLoaded(Scene _, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Additive) { return; }
        m_Transitioning = false;
    }

    public static void Reload()
    {
        if (m_Transitioning) { return; }
        m_Transitioning = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Load(SCENES scene)
    {
        if (m_Transitioning) { return; }
        m_Transitioning = true;
        SceneManager.LoadScene((int)scene);
    }

    public static void Next()
    {
        if (m_Transitioning) { return; }
        m_Transitioning = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static SCENES GetCurrentScene()
    {
        return (SCENES)SceneManager.GetActiveScene().buildIndex;
    }
}
