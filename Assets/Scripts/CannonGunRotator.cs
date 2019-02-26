using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGunRotator : MonoBehaviour
{
    private Quaternion targetRotation;

    public void Activate()
    {
        targetRotation = Quaternion.Euler(-25, transform.rotation.eulerAngles.y, 0);
    }

    public void Deactivate()
    {
        targetRotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    public void RotateRandomly()
    {
        targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, Random.Range(0, 360), 0);
    }

    public void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
    }
}
