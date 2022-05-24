using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public void OnReturnButtonClicked()
    {
        SceneLoader.Load(SCENES.MENU);
    }
}
