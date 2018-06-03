using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour {

    public GameObject explosion;

    private void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.tag =="Player" ) {
            Camera.main.transform.parent = null;
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(other.transform.parent.parent.gameObject);
        }

    }
}
