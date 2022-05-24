using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXDestroy : MonoBehaviour
{
    private AudioSource m_Source;

    // Start is called before the first frame update
    void Start()
    {
        m_Source = GetComponent<AudioSource>();
        Destroy(gameObject, m_Source.clip.length  + 1);
    }
}
