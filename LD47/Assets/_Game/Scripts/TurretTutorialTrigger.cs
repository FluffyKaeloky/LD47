using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTutorialTrigger : MonoBehaviour
{
    public Rigidbody can = null;

    private void Start()
    {
        can.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInput pi = other.GetComponentInParent<PlayerInput>();

        if (pi != null && pi.gameObject.tag == "Player")
        {
            can.isKinematic = false;
            gameObject.SetActive(false);
        }
    }
}
