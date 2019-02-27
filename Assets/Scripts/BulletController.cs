using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Vector3 cannonPosition;
    private bool isWatched;
    private LineController lineController;
    private IEnumerator measureCoroutine;

    private IEnumerator Measure()
    {
        yield return new WaitForSeconds(3f);
        isWatched = true;
    }


    public void OnWatchStart()
    {
        measureCoroutine = Measure();
        StartCoroutine(measureCoroutine);
    }

    public void OnWatchEnd()
    {
        StopCoroutine(measureCoroutine);
        lineController.RemoveTarget();
        isWatched = false;
    }

    public void Start()
    {
        lineController = GameObject.Find("Line").GetComponent<LineController>();
    }

    public void Update()
    {
        if (isWatched)
        {
            lineController.SetTarget(transform.position);
        }
    }
}
