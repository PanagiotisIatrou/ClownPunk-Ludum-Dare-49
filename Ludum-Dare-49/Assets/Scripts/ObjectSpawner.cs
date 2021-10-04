using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] ObjectPrefabs;
    public Transform ObjectsHolder;
    public Transform FrogTR;
    private float spawnerTimer = 0f;
    private int objectsPerSecond = 1;
    private Camera mainCamera;

	private void Start()
	{
        mainCamera = Camera.main;
	}

	private void Update()
    {
        if (GameManager.Instance.getIsPlaying() == false)
            return;

        spawnerTimer += Time.deltaTime;
        if (spawnerTimer >= 1f / objectsPerSecond)
		{
            spawnerTimer = 0f;
            int r = Random.Range(0, ObjectPrefabs.Length);
            Vector3 spawnPos = new Vector3(FrogTR.position.x, FrogTR.position.y, -2f);
            GameObject obj = Instantiate(ObjectPrefabs[r], spawnPos, Quaternion.identity, ObjectsHolder);
            obj.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-0.5f, 0.5f), ForceMode2D.Impulse);

            if (!ButtonListeners.isAudioMuted)
                AudioSource.PlayClipAtPoint(GameManager.Instance.ItemThrowSound, mainCamera.transform.position, 0.5f);
        }
    }

    public void Restart()
    {
        spawnerTimer = 0;
    }
}
