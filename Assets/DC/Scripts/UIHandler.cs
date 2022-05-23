using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject m_StarFighterPrefab = null;

    [SerializeField]
    private ulong m_StarFigherCost = 0;

    public void OnStarFighterButtonClick()
    {
        Player player = Player.Instance;
        ulong res = player.GetResources();
        if (res >= m_StarFigherCost)
        {
            player.RemoveResources(m_StarFigherCost);
            Instantiate(m_StarFighterPrefab, new Vector3(Random.Range(-0.1f, 0.1f), 0, Random.Range(-0.1f, 0.1f)), Quaternion.identity);
        }
    }
}
