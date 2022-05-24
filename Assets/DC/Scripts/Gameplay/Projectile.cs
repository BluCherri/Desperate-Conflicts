using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Vector3 m_ForwardDir = Vector3.zero;

    private Rigidbody m_RB;

    [SerializeField]
    private float m_Speed = 50.0f;

    [SerializeField]
    private ushort m_Damage = 100;

    [SerializeField]
    private GameObject m_HitSFX = null;

    private void Start()
    {
        m_ForwardDir = transform.TransformDirection(Vector3.forward);
        m_RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        m_RB.MovePosition(transform.position + m_ForwardDir * m_Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.TryGetComponent<Target>(out Target target))
        {
            Instantiate(m_HitSFX, transform.position, transform.rotation);
            target.DealDamage(m_Damage);
            Destroy(gameObject);
        }
    }
}
