using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP_LevelChanger : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneLoader.Next();
    }
}
