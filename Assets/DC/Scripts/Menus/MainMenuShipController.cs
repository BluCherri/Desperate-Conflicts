using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuShipController : MonoBehaviour
{
    [SerializeField]
    private float m_DestroyX = -200f;

    private void Update()
    {
        if (transform.position.x <= m_DestroyX)
        {
            Destroy(gameObject);
        }
    }
}
