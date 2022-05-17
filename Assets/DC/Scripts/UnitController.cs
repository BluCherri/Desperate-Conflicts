using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[RequireComponent(typeof(NavMeshAgent), typeof(Targetter), typeof(Target))]
public class UnitController : MonoBehaviour
{
    public void SetDestination(Vector3 destination)
    {
        if (!NavMesh.SamplePosition(destination, out NavMeshHit hit, 5f, NavMesh.AllAreas)) { return; }

        m_Agent.SetDestination(hit.position);
    }

    public void ClearDestination()
    {
        m_Agent.ResetPath();
    }

    public void Select()
    {
        m_OnSelected?.Invoke();
    }

    public void Deselect()
    {
        m_OnDeselected?.Invoke();
    }

    #region Private
    private NavMeshAgent m_Agent;

    [SerializeField]
    private float m_MaxDistanceToTarget = 0.5f;

    public float MaxDistanceToTarget { get => m_MaxDistanceToTarget; }

    [SerializeField]
    private UnityEvent m_OnSelected = null;

    [SerializeField]
    private UnityEvent m_OnDeselected = null;

    private void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawLine(transform.position, transform.position + forward * 100, Color.red);

        if (Vector3.Distance(transform.position, m_Agent.destination) < m_MaxDistanceToTarget)
        {
            ClearDestination();
        }
    }

    #endregion
}
