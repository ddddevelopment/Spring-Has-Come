using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowController : MonoBehaviour
{
    private SpawnerEnvironment Spawner;

    private void Start() 
    {
        Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerEnvironment>();
    }

    private void Update() 
    {
        DestroySnow();
    }

    private void DestroySnow()
    {
        if (transform.position.y < Spawner.destroyPosition.y)
            Destroy(gameObject);
    }
}
