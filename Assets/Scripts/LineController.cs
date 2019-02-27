using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineController : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Text counterText;
    public Transform cannonTransform;
    public Animator counterCanvasAnimator;

    private Vector3 cannonPosition;
    private Vector3 targetPosition;

    void Start()
    {
        cannonPosition = cannonTransform.position;
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.SetPositions(new[] {
            cannonPosition,
            cannonPosition
        });

        targetPosition = cannonPosition;
    }

    public void SetTarget(Vector3 position)
    {
        targetPosition = position;
        counterText.text = Vector3.Distance(lineRenderer.GetPosition(0), targetPosition).ToString("0.00") + "m";
        counterCanvasAnimator.SetBool("IsVisible", true);
    }

    public void RemoveTarget()
    {
        targetPosition = cannonPosition;
        counterCanvasAnimator.SetBool("IsVisible", false);
    }

    public void Update()
    {
        lineRenderer.SetPosition(1, Vector3.Lerp(lineRenderer.GetPosition(1), targetPosition, 5f * Time.deltaTime));
    }
}
