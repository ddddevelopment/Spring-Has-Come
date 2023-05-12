using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public Vector2 directionOfMovement;
    private Rigidbody2D rb;

    private  PlayerController Player;
    private SpawnerEnvironment Spawner;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerEnvironment>();
    }

    private void Update() 
    {
        DestroyEnvironment();
    }

    private void FixedUpdate()
    {
        MoveEnvironment();
        MoveSnow();
    }

    private void MoveEnvironment()
    {
        directionOfMovement = new Vector2(0, -Player.GetComponent<PlayerController>().speed);
        if (Player.directionOfMovement.y > 0)
        {
            directionOfMovement.y += -Player.directionOfMovement.y;
        } 

        rb.velocity = directionOfMovement;
    }

    private void MoveSnow()
    {
        for (int i = 0; i < Spawner.SnowElements.Count; i++)
        {
            if (Spawner.SnowElements[i]) 
            {
                Spawner.SnowElements[i].GetComponent<Rigidbody2D>().velocity = directionOfMovement;
                Spawner.SnowElements[i].transform.SetParent(gameObject.transform);
            }
            else 
            {
                Spawner.SnowElements.RemoveAt(i);
                i--;
            }
        }   
    }

    private void DestroyEnvironment()
    {
        if (transform.position.y < Spawner.destroyPosition.y)
        {
            Destroy(gameObject);
        }
    }
}
