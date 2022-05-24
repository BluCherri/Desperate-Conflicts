using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuShipSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_MainMenuShip = null;

    [SerializeField]
    private float m_ShipSpawnTimer = 4.0f;

    [SerializeField]
    private float m_MinSpawnHeight = 0f;

    [SerializeField]
    private float m_MaxSpawnHeight = 0f;

    [SerializeField]
    private float m_MinSpawnZ = 0f;

    [SerializeField]
    private float m_MaxSpawnZ = 0f;

    private void Start()
    {
        StartCoroutine(nameof(ShipTimer));
    }

    IEnumerator ShipTimer()
    {
        while (true)
        {
            Instantiate(m_MainMenuShip, new Vector3(150, Random.Range(m_MinSpawnHeight, m_MaxSpawnHeight), Random.Range(m_MinSpawnZ, m_MaxSpawnZ)), Quaternion.Euler(0, -90, 0));
            yield return new WaitForSeconds(m_ShipSpawnTimer);
        }
    }
}
