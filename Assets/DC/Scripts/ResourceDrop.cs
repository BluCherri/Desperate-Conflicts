using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDrop : MonoBehaviour
{
    [SerializeField]
    private ulong m_ResourceValue = 500;

    private void OnDestroy()
    {
        Player.Instance.AddResources(m_ResourceValue);
    }
}
