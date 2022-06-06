using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private RectTransform m_UnitSelectionArea = null;

    [SerializeField]
    private LayerMask m_LayerMask;

    private Camera m_MainCamera;
    private List<UnitController> m_SelectedUnits = new List<UnitController>();
    private Vector2 m_DragStartPos;

    public void RemoveUnit(UnitController controller)
    {
        if (m_SelectedUnits.Contains(controller)) { m_SelectedUnits.Remove(controller); }
    }

    public void RemoveAllUnits()
    {
        m_SelectedUnits.Clear();
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        m_MainCamera = Camera.main;
    }

    private void OnLevelWasLoaded(int level)
    {
        m_MainCamera = Camera.main;

        if (level == (int)SCENES.TMP_END || level == (int)SCENES.MENU)
        {
            Player.Instance.HideGameUI();
        }
        else
        {
            Player.Instance.ShowGameUI();
        }
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartSelectionArea();
        }
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            ClearSelectionArea();
        }
        else if (Mouse.current.leftButton.isPressed)
        {
            UpdateSelectionArea();
        }
        else if (Mouse.current.rightButton.isPressed)
        {
            SetUnitTarget();
        }

        if (Player.Instance.GetResources() == 0 && m_SelectedUnits.Count == 0 && SceneLoader.GetCurrentScene() != SCENES.MENU && SceneLoader.GetCurrentScene() != SCENES.TMP_END)
        {
            // They lost
        }
    }

    private void SetUnitTarget()
    {
        Ray ray = m_MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_LayerMask)) { return; }

        Target target = null;

        if (hit.collider.TryGetComponent<Target>(out Target newTarget))
        {
            if (!newTarget.TryGetComponent<UnitController>(out UnitController controller))
            {
                target = newTarget;
            }
        }

        foreach (UnitController controller in m_SelectedUnits)
        {
            controller.ClearDestination();
            controller.GetComponent<Targetter>().ClearTarget();
            if (target != null)
            {
                controller.GetComponent<Targetter>().SetTarget(target);
            }
            else
            {
                controller.SetDestination(hit.point);
            }
        }
    }

    private void StartSelectionArea()
    {
        foreach (UnitController selected in m_SelectedUnits)
        {
            selected.Deselect();
        }

        m_SelectedUnits.Clear();

        m_UnitSelectionArea.gameObject.SetActive(true);
        m_DragStartPos = Mouse.current.position.ReadValue();

        UpdateSelectionArea();
    }

    private void UpdateSelectionArea()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();

        float aW = mousePos.x - m_DragStartPos.x;
        float aH = mousePos.y - m_DragStartPos.y;

        m_UnitSelectionArea.sizeDelta = new Vector2(Mathf.Abs(aW), Mathf.Abs(aH));
        m_UnitSelectionArea.anchoredPosition = m_DragStartPos + new Vector2(aW / 2, aH / 2);
    }

    private void ClearSelectionArea()
    {
        m_UnitSelectionArea.gameObject.SetActive(false);

        if (m_UnitSelectionArea.sizeDelta.magnitude == 0)
        {
            Ray ray = m_MainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, m_LayerMask)) { return; }

            if (!hit.collider.TryGetComponent<UnitController>(out UnitController unitController)) { return; }

            m_SelectedUnits.Add(unitController);

            foreach (UnitController selected in m_SelectedUnits)
            {
                selected.Select();
            }

            return;
        }

        Vector2 min = m_UnitSelectionArea.anchoredPosition - (m_UnitSelectionArea.sizeDelta / 2);
        Vector2 max = m_UnitSelectionArea.anchoredPosition + (m_UnitSelectionArea.sizeDelta / 2);

        foreach (UnitController controller in FindObjectsOfType<UnitController>())
        {
            Vector3 screenPos = m_MainCamera.WorldToScreenPoint(controller.transform.position);

            if (screenPos.x > min.x && screenPos.x < max.x &&
                screenPos.y > min.y && screenPos.y < max.y)
            {
                m_SelectedUnits.Add(controller);
                controller.Select();
            }
        }
    }
}
