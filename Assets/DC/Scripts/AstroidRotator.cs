using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidRotator : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 5.0f;

    private bool x, y, z;

    private void Start()
    {
        x = Random.Range(0, 2) == 1;
        y = Random.Range(0, 2) == 1;
        z = Random.Range(0, 2) == 1;

        m_Speed = Random.Range(5.0f, 15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        /*transform.Rotate(new Vector3((x ? 1 : -1) * m_Speed * Time.deltaTime, (y ? 1 : -1) * m_Speed * Time.deltaTime, (z ? 1 : -1) * m_Speed * Time.deltaTime));*/
        transform.Rotate(new Vector3(0, (y ? 1 : -1) * m_Speed * Time.deltaTime, 0));
    }
}
