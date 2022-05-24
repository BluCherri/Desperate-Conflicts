using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void Load(SCENES scene)
    {
        SceneManager.LoadScene((int)scene);
    }

    public static void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
