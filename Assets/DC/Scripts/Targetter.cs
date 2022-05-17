using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetter : MonoBehaviour
{
    private Target m_CurrentTarget = null;
    public Target CurrentTarget { get => m_CurrentTarget; }

    private UnitController m_UnitController = null;

    [SerializeField]
    private GameObject m_ProjectilePrefab = null;

    [SerializeField]
    private Transform m_ProjectileSpawn;

    [SerializeField]
    private float m_ProjectileSpawnTimerStart = 1f;
    private float m_ProjectileSpawnTimer;

    private void Start()
    {
        m_UnitController = GetComponent<UnitController>();
        m_ProjectileSpawnTimer = m_ProjectileSpawnTimerStart;
    }

    public void SetTarget(Target target)
    {
        m_CurrentTarget = target;

        if (Vector3.Distance(transform.position, target.transform.position) > m_UnitController.MaxDistanceToTarget * 15)
        {
            m_UnitController.SetDestination(target.transform.position);
        }
    }

    public void ClearTarget()
    {
        m_CurrentTarget = null;
    }

    private void Update()
    {
        if (m_ProjectileSpawnTimer > 0)
        {
            m_ProjectileSpawnTimer -= Time.deltaTime;
        }

        if (m_CurrentTarget != null)
        {
            if (Vector3.Distance(transform.position, m_CurrentTarget.transform.position) < m_UnitController.MaxDistanceToTarget * 15)
            {
                Vector3 _dir = (m_CurrentTarget.transform.position - transform.position).normalized;
                Quaternion _lookDir = Quaternion.LookRotation(_dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, _lookDir, 5 * Time.deltaTime);

                m_UnitController.ClearDestination();
                if (m_ProjectileSpawnTimer < 0)
                {
                    Instantiate(m_ProjectilePrefab, m_ProjectileSpawn.position, m_ProjectileSpawn.rotation);
                    m_ProjectileSpawnTimer = m_ProjectileSpawnTimerStart;
                }
            }
        }

    }
}
