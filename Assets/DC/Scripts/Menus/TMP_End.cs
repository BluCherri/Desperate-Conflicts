using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP_End : MonoBehaviour
{
    public void OnRestartButtonClicked()
    {
        Player.Instance.ResetResources();
        SceneLoader.Load(SCENES.MENU);
    }
}
