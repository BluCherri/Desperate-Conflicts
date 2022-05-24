using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUI : MonoBehaviour
{
    private ulong m_ResourcesValue = 0;

    private Player m_Player = null;

    private void Start()
    {
        m_Player = GetComponent<Player>();
    }

    private void OnGUI()
    {
        GUILayout.BeginVertical();

        GUILayout.Label("Resources");
        GUILayout.Label(m_ResourcesValue.ToString());

        if (GUILayout.Button("Refresh")) { UpdateValues(); }

        if (GUILayout.Button("Add Resources")) { AddResources(); }
        if (GUILayout.Button("Remove Resources")) { RemoveResources(); }

        GUILayout.EndVertical();
    }

    private void Update()
    {
        UpdateValues();
    }

    private void UpdateValues()
    {
        m_ResourcesValue = m_Player.GetResources();
    }

    private void AddResources()
    {
        m_Player.AddResources(100);
        UpdateValues();
    }

    private void RemoveResources()
    {
        m_Player.RemoveResources(100);
        UpdateValues();
    }
}
