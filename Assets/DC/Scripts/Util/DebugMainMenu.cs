using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMainMenu : MonoBehaviour
{
    private void OnGUI()
    {
        var fps = 1.0 / Time.deltaTime;
        GUILayout.Label(fps.ToString());
    }
}
