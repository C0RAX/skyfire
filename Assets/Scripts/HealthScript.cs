using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.GetComponent<PlayerHealth>().AddHealth();
            Destroy(gameObject);
        }

    }
}
