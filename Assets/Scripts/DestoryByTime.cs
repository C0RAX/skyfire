using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByTime : MonoBehaviour
{
    private float lifeTime = 5f;

    private void Start()
    {
        Destroy(gameObject,lifeTime);
        
    }
}
