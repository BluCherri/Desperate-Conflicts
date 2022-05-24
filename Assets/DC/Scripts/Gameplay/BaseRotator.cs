using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseRotator : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 1 * m_Speed * Time.deltaTime, 0);
    }
}
