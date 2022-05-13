using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private EnemyAI enemyPrefab;
	[SerializeField] private float spawnInterval;
	[SerializeField] private int maxEnemiesNumber;
	[SerializeField] private Player player;
	int Rand;
	int Lenght = 4;
	List<int> list = new List<int>();
	private int ind = 1;

	private List<EnemyAI> spawnedEnemies = new List<EnemyAI>();
	private float timeSinceLastSpawn;

	private void Start()
	{
		timeSinceLastSpawn = spawnInterval;

		list = new List<int>(new int[Lenght]);

		for (int j = 1; j < Lenght; j++)
		{
			Rand = Random.Range(0, 4);

			while (list.Contains(Rand))
			{
				Rand = Random.Range(0, 4);
			}

			list[j] = Rand;
			print(list[j]);
		}

	}

	private void Update()
	{
		timeSinceLastSpawn += Time.deltaTime;
		if(timeSinceLastSpawn > spawnInterval)
		{
			timeSinceLastSpawn = 0f;
			if(spawnedEnemies.Count < maxEnemiesNumber)
			{
				SpawnEnemy();
			}
		}
	}

	private void SpawnEnemy()
	{
		EnemyAI enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
		int spawnPointindex = spawnedEnemies.Count % spawnPoints.Length;
		enemy.Init(player, spawnPoints[list[ind]]);
		spawnedEnemies.Add(enemy);
		ind++;

	}

	
}
