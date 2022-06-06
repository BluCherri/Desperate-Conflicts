using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player m_Instance;
    public static Player Instance { get => m_Instance; }

    private PlayerData m_PlayerData;
    public PlayerData Data { get => m_PlayerData; }

    [SerializeField]
    private GameObject m_SelectUI = null;

    [SerializeField]
    private GameObject m_BuyButtons = null;

    [SerializeField]
    private GameObject m_Music = null;
    
    public void ShowGameUI()
    {
        m_SelectUI.SetActive(true);
        m_BuyButtons.SetActive(true);
        m_Music.SetActive(true);
    }

    public void HideGameUI()
    {
        m_SelectUI.SetActive(false);
        m_BuyButtons.SetActive(false);
        m_Music.SetActive(false);
    }

    private void Start()
    {
        m_PlayerData = new PlayerData();
        AddResources(50);
        if (Instance != null)
        {
            Debug.LogWarning("Another player already exists!");
            Destroy(gameObject);
        }
        m_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void ResetResources()
    {
        RemoveResources(Data.Resources);
        AddResources(50);
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
