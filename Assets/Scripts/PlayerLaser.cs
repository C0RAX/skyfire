using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLaser : MonoBehaviour
{

    
    public float startingPower = 100;                            // The amount of power the player starts the game with.
    public float currentPower;                                   // The current power the player has.
    public Slider powerSlider;

    private LineRenderer line;

    // Use this for initialization
    void Start()
    {

        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
        gameObject.GetComponent<Light>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            {
                StopCoroutine("FireLaser");
                StartCoroutine("FireLaser");
            }
        }
    }

    public void AddPower()
    {
        currentPower += 50;
        if (currentPower < 0) { currentPower = 0; }
        if (currentPower > 100) { currentPower = 100; }
        powerSlider.value = currentPower;
    }

    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (Input.GetButton("Fire1") && currentPower > 0)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit Hit;

            gameObject.GetComponent<Light>().enabled = true;

            line.SetPosition(0, ray.origin);

            if (Physics.Raycast(ray, out Hit, 200))
            {
                line.SetPosition(1, Hit.point);
                if (Hit.collider.gameObject.tag.Equals("Enemy"))
                {
                    Hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(2,Hit.point);
                }
            }
            else { line.SetPosition(1, ray.GetPoint(200)); }

            currentPower -= 2 * Time.deltaTime;
            if(currentPower < 0) { currentPower = 0; }
            if (currentPower > 100) { currentPower = 100; }
            powerSlider.value = currentPower;

            yield return null;
        }

        gameObject.GetComponent<Light>().enabled = false;

        line.enabled = false;
    }
}
