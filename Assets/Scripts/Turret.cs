using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    //Turrets track play but need to be improved to lead the player right now there are shooting at the current position of player.

    public Transform target;

    [Header("Attributes")]
    public float range = 100f;
    public Transform rotateYAxis;
    public Transform rotateXAxis;
    public float turnSpeed;
    public string Player = "Player";

    public GameObject player;


    [Header("Setup Attributes")]


    public GameObject bulletPrefab;
    public Transform firePoint;
    public GameObject explosion;

    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
		
	}

    void UpdateTarget()
    {
        if (target != null)
        {

            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < range)
            {
                target = player.transform;
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (target == null) { return; }

        Vector3 targetDir = target.position  - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDir);
        Vector3 rotation = Quaternion.Lerp(rotateYAxis.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotateYAxis.rotation = Quaternion.Euler (rotation.x, rotation.y,0f);
	}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
