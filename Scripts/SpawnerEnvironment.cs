using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnvironment : MonoBehaviour
{
    [SerializeField] private GameObject EnvironmentPrefab;
    public GameObject Environment;

    [SerializeField] GameObject SnowPrefab;
    public List<GameObject> SnowElements = new List<GameObject>() {};

    private Vector3 spawnPosition;
    public Vector3 destroyPosition;
    public Vector3 startPosition;
    private Vector3 distanceBetweenTwoEnvironments = new Vector3(0,23,0);

    private Vector2 rangeOfDifficultyLevel;

    private void Awake() 
    {
        Environment = Instantiate(EnvironmentPrefab, new Vector3(0, 2, 0), Quaternion.identity);
    }

    private void Start() 
    {
        startPosition = Environment.transform.position;
        spawnPosition = startPosition + distanceBetweenTwoEnvironments;
        destroyPosition = startPosition - distanceBetweenTwoEnvironments - new Vector3(0, 2, 0);
    }

    public void Spawn()
    {   
        Environment = Instantiate(EnvironmentPrefab, spawnPosition, Quaternion.identity);
        
        for (int i = 0; i < Random.Range(20, 31); i++)
        {
            Vector3 positionSnowElement = new Vector3((int)Random.Range(-5.5f, 5.5f), (int)Random.Range(13, 36), 0);
            SnowElements.Add(Instantiate(SnowPrefab, positionSnowElement, Quaternion.identity));
        }
    }
}
