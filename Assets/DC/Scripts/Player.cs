using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Allow player to buy ships with resources.

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
