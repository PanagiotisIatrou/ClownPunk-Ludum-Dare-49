using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;
    public Transform ObjectsHolder;
    private Vector2 spawnPos = new Vector2(0f, 3.5f);
    private float spawnerTimer = 0f;
    private int objectsPerSecond = 1;

    private float Bounds = 1.8f;
    private void Update()
    {
        if (GameManager.Instance.getIsPlaying() == false)
            return;

        spawnerTimer += Time.deltaTime;
        if (spawnerTimer >= 1f / objectsPerSecond)
		{
            spawnerTimer = 0f;
            int r = Random.Range(0, ObjectPrefabs.Length);
            Instantiate(ObjectPrefabs[r], spawnPos + new Vector2(Random.Range(-Bounds, Bounds), 0f), Quaternion.identity, ObjectsHolder);
		}
    }

    public void Restart()
    {
        spawnerTimer = 0;
    }
}
