using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelTargetType
{
    NONE,
    DESTROY,
    RESOURCES
}

public class LevelTarget : MonoBehaviour
{
    [SerializeField] private LevelTargetType m_Type = LevelTargetType.NONE;

    [SerializeField] private List<GameObject> m_Destroy = new List<GameObject>();

    [SerializeField] private ulong m_Resources = 0;

    public static LevelTarget instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (m_Type)
        {
            case LevelTargetType.NONE:
                SceneLoader.Next();
                break;
            case LevelTargetType.DESTROY:
                if (m_Destroy.Count == 0)
                {
                    SceneLoader.Next();
                }
                break;
            case LevelTargetType.RESOURCES:
                throw new System.Exception("NOT IMPLEMENTED! DON'T USE!");
                break;
            default:
                break;
        }
    }

    public void TryRemoveShip(GameObject go)
    {
        if (m_Destroy.Contains(go))
        {
            m_Destroy.Remove(go);
        }
    }
}
