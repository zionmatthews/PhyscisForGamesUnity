using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBehavior : MonoBehaviour
{
    public float launchForce;
    void OnTriggerStay (Collider other)
    {
        other.GetComponent<Rigidbody>().AddForce(Vector3.up * launchForce, ForceMode.Acceleration);
    }
}
