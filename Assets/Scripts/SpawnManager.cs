using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] enemyPrefab;

	private GameObject player;

	private float startDelay = 3f;
	private float spawnRate = 2f;
	private float spawnRange = 10f;

	void Start()
	{
		player = GameObject.Find("Player");
		InvokeRepeating("SpawnEnemies", startDelay, spawnRate);
	}

	private void SpawnEnemies()
	{
		Quaternion spawnRotation = Quaternion.Euler(0f, 0f, 0f);
		Instantiate(enemyPrefab[Random.Range(0,enemyPrefab.Length)], GenerateSpawnPosition(), spawnRotation);
	}

	private Vector3 GenerateSpawnPosition()
	{
		float spawnPosX = player.transform.position.x + Random.Range(-spawnRange, spawnRange);
		if (spawnPosX > spawnRange)
		{ spawnPosX = spawnRange; }
		if (spawnPosX < -spawnRange)
		{ spawnPosX = -spawnRange; }

		float spawnPosZ = player.transform.position.z + Random.Range(-spawnRange, spawnRange);
		if (spawnPosZ > spawnRange)
		{ spawnPosZ = spawnRange; }
		if (spawnPosZ < -spawnRange)
		{ spawnPosZ = -spawnRange; }

		Vector3 randomPos = new Vector3(spawnPosX,0f,spawnPosZ);
		return randomPos;
	}
}
