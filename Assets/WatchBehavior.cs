using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchBehavior : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Cannon")
        {
            other.gameObject.GetComponent<CannonShooter>().OnWatchStart();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.name == "Cannon")
        {
            other.gameObject.GetComponent<CannonShooter>().OnWatchEnd();
        }
    }
}
