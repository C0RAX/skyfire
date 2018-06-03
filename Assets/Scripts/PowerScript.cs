using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerScript : MonoBehaviour {

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.parent.parent.GetComponentInChildren<PlayerLaser>().AddPower();
            Destroy(gameObject);
        }

    }
}
