using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {
    float spawnInterval;
    float timeSinceLastSpawn;
    float positionX;
    public GameObject objectToSpawn;
	// Use this for initialization
	void Start () {
        spawnInterval = 3 - GameManager.level*0.2f;
        timeSinceLastSpawn = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
		if(timeSinceLastSpawn > spawnInterval)
        {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            transform.position = new Vector3(Random.Range(-7, 7), transform.position.y, transform.position.z);
            timeSinceLastSpawn = 0;
        }
        else
        {
            timeSinceLastSpawn += Time.deltaTime;
        }
	}
}
