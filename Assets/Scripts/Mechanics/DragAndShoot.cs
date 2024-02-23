using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndShoot : MonoBehaviour
{
    [SerializeField] private Transform projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform distancePoint;
    [SerializeField] private LineRenderer lineRenderer;
    
    [SerializeField] private float launchForce = 1.5f;
    [SerializeField] private float trajectoryTimeStep = 0.05f;
    [SerializeField] private int trajectoryStepCount = 15;
    [SerializeField] private int minDistance = 5;

    private Vector2 velocity, startMousePos, currentMousePos;

    private void Update()
    {
        if (IsDistanceValid() && !IsMouseOverUIObject() && GameManager.Instance.IsPlayerTurn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                currentMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                velocity = (startMousePos - currentMousePos) * launchForce;
                DrawTrajectory();
                RotateLauncher();
            }

            if (Input.GetMouseButtonUp(0))
            {
                FireProjectile();
                ClearTrajectory();
            }
        }
    }
    
    bool IsDistanceValid()
    {
        Vector2 pstn = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Vector3.Distance(distancePoint.transform.position, pstn) < minDistance;
    }
    
    public bool IsMouseOverUIObject()
    {
        Vector3 mousePosition = Input.mousePosition;

        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = mousePosition;

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.layer == LayerMask.NameToLayer("UIRaycast"))
            {
                return true;
            }
        }
        
        return false;
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryStepCount];
        for (int i = 0; i < trajectoryStepCount; i++)
        {
            float t = i * trajectoryTimeStep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;
            positions[i] = pos;
        }
        lineRenderer.positionCount = trajectoryStepCount;
        lineRenderer.SetPositions(positions);
    }

    void FireProjectile()
    {
        Transform pr = Instantiate(projectilePrefab, spawnPoint.position, quaternion.identity);
        pr.GetComponent<Rigidbody2D>().velocity = velocity;
        GameManager.Instance.EndRound();
    }

    void RotateLauncher()
    {
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    void ClearTrajectory()
    {
        lineRenderer.positionCount = 0;
    }
}