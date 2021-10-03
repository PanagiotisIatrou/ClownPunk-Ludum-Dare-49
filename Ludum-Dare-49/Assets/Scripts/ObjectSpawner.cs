using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;
    public Transform ObjectsHolder;
    private Vector3 spawnPos = new Vector3(0f, 3.5f, -2f);
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
            GameObject obj = Instantiate(ObjectPrefabs[r], spawnPos + new Vector3(Random.Range(-Bounds, Bounds), 0f), Quaternion.identity, ObjectsHolder);
            obj.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-0.5f, 0.5f), ForceMode2D.Impulse);
		}
    }

    public void Restart()
    {
        spawnerTimer = 0;
    }
}
