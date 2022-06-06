using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMP_LevelChanger : MonoBehaviour
{
    private void OnDestroy()
    {
        Player.Instance.GetComponent<PlayerInput>().RemoveAllUnits();
        SceneLoader.Next();
    }
}
