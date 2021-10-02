using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject ObjectPrefab;
    public Transform ObjectsHolder;
    private Vector2 spawnPos = new Vector2(0f, 3.5f);
    private float spawnerTimer = 0f;
    private int objectsPerSecond = 1;
        
    private void Update()
    {
        spawnerTimer += Time.deltaTime;
        if (spawnerTimer >= 1f / objectsPerSecond)
		{
            spawnerTimer = 0f;
            Instantiate(ObjectPrefab, spawnPos + new Vector2(Random.Range(-1.5f, 1.5f), 0f), Quaternion.identity, ObjectsHolder);
		}
    }

}
