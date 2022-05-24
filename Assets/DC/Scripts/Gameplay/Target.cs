using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private Transform m_LookAtPoint = null;
    public Transform LookAtPoint { get => m_LookAtPoint; }

    [SerializeField]
    private ushort m_Health = 400;
    public ushort Health { get => m_Health; }

    [SerializeField]
    private GameObject m_DestroySFX = null;

    public void DealDamage(ushort value)
    {
        if (m_Health <= value)
        {
            //TODO: Create Destroy Effect, hide mesh, and set countdown till destroyed
            Instantiate(m_DestroySFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            m_Health -= value;
        }
    }
}
