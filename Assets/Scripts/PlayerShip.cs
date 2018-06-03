using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShip : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject explosion;

    float magic = 40.0f;
    float forwardInput = 0.00f;
    float pitchInput = 0.00f;
    float rollInput = 0.00f;
    float throttle = 0.00f;

    //there was intent to add yaw but i never implimented it
    //float yawInput = 0.00f;


    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 moveCamTo = transform.position - transform.forward * 5f + Vector3.up * 2.5f;
        float bias = 0.95f;
        Camera.main.transform.position = Camera.main.transform.position * bias + moveCamTo * (1.0f - bias); ;
        Camera.main.transform.LookAt(transform.position + transform.forward * 30f);

        forwardInput = Input.GetAxis("Throttle");
        pitchInput = Input.GetAxis("Vertical");
        rollInput = Input.GetAxis("Horizontal");
        //yawInput = Input.GetAxis("Yaw");


        if (throttle < 50f && throttle > -1) { throttle += forwardInput; } else if(throttle >= 50f) { throttle = 50f; }
        else if(throttle < 0){ throttle = 0f; }
        GetComponent<Rigidbody>().velocity = transform.forward * throttle;


        rollInput *= Time.deltaTime * magic * 2;
        pitchInput *= Time.deltaTime * magic;

        transform.Rotate(0, 0, -rollInput);
        transform.Rotate(pitchInput, 0, 0);

        if (Terrain.activeTerrain != null)
        {

            float terrainHeightAtPos = Terrain.activeTerrain.SampleHeight(transform.position);

            if (terrainHeightAtPos > transform.position.y)
            {
                Camera.main.transform.parent = null;
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);    
            }
            if (transform.position.y <= 6)
            {
                Camera.main.transform.parent = null;
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }


    }

}