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
	private int maxEnemiesNumber;
	[SerializeField] public EnemiesSO enemies;
	[SerializeField] private Player player;
	int Rand;
	int Lenght = 5;
	List<int> list = new List<int>();
	private int ind = 0;

	private List<EnemyAI> spawnedEnemies = new List<EnemyAI>();
	private float timeSinceLastSpawn;

	private void Start()
	{
		maxEnemiesNumber = enemies.Value;
		timeSinceLastSpawn = spawnInterval;

		list = new List<int>(new int[Lenght]);

		for (int j = 1; j < Lenght; j++)
		{
			Rand = Random.Range(0, 5);

			while (list.Contains(Rand))
			{
				Rand = Random.Range(0, 5);
			}

			list[j] = Rand;
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
