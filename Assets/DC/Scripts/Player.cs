using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerData m_PlayerData;
    public PlayerData Data { get => m_PlayerData; }

    public void AddResources(ulong value)
    {
        if ((Data.Resources + value) > ulong.MaxValue) throw new System.Exception();
        m_PlayerData.Resources += value;
    }

    public void RemoveResources(ulong value)
    {
        if ((Data.Resources - value) < ulong.MinValue) throw new System.Exception();
        m_PlayerData.Resources -= value;
    }

    public ulong GetResources()
    {
        return Data.Resources;
    }
}
