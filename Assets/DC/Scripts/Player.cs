using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player m_Instance;
    public static Player Instance { get => m_Instance; }

    private PlayerData m_PlayerData;
    public PlayerData Data { get => m_PlayerData; }

    private void Start()
    {
        m_PlayerData = new PlayerData();
        AddResources(50);
        m_Instance = this;
    }

    public void AddResources(ulong value)
    {
        if ((Data.Resources + value) < Data.Resources) throw new System.Exception();
        m_PlayerData.Resources += value;
    }

    public void RemoveResources(ulong value)
    {
        if ((Data.Resources - value) > Data.Resources) throw new System.Exception();
        m_PlayerData.Resources -= value;
    }

    public ulong GetResources()
    {
        return Data.Resources;
    }
}
