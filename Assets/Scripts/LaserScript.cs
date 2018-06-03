using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    LineRenderer line;

    public float fireRate;
    private float fireCountDown = 0f;

    public GameObject player;

    // Use this for initialization
    void Start () {

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

    
        {
            {
                StopCoroutine("FireLaser");
                StartCoroutine("FireLaser");
            }
        }

        fireCountDown -= Time.deltaTime;
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        float shootTime = 1f;

        while (shootTime >0)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit Hit;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out Hit, 100))
            {
                line.SetPosition(1, Hit.point);
                if (Hit.collider.gameObject.tag.Equals("Player"))
                {
                    Hit.collider.gameObject.transform.parent.parent.GetComponent<PlayerHealth>().TakeDamage(1,Hit.point);
                }
            }
            else
                line.SetPosition(1, ray.GetPoint(100));

            shootTime -= Time.deltaTime;
            yield return null;
        }

        line.enabled = false;
    }
}
