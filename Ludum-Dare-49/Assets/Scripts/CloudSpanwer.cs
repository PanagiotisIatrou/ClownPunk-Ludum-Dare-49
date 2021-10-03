using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpanwer : MonoBehaviour
{
    public GameObject[] CloudPrefabs;
    public Transform CloudsHolder;
    private float cloudTimer = 5f;
    private float maxCloudTimer = 5;
    private Vector2 spawnBoundsY = new Vector2(0f, 4f);

    private void Update()
    {
        cloudTimer += Time.deltaTime;
        if (cloudTimer >= maxCloudTimer)
		{
            cloudTimer = 0f;
            GameObject cloud = null;
            int r = Random.Range(0, CloudPrefabs.Length);
            if (AirManager.Instance.getTypeAir()!=2)
                cloud = Instantiate(CloudPrefabs[r], new Vector3(-8f, Random.Range(spawnBoundsY.x, spawnBoundsY.y), 1f), Quaternion.identity, CloudsHolder);
            else
                cloud = Instantiate(CloudPrefabs[r], new Vector3(8f, Random.Range(spawnBoundsY.x, spawnBoundsY.y), 1f), Quaternion.identity, CloudsHolder);
            cloud.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
		}
    }
}
