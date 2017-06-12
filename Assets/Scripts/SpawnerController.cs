using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	private Transform[] spawners;

	private int nextSpawner;
	private int nextOperation;
	private int nextOperand;

	public float spawnFreqFactor;

	void Awake()
	{
		// get all spawners under the spawner controller
		spawners = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) 
		{
			spawners [i] = transform.GetChild (i);
		}
	}

	// Use this for initialization
	void Start ()
	{
		// Spawn operations randomly every few seconds
		StartCoroutine(spawnOperations());
	}

	// Update is called once per frame
	void Update ()
	{

	}

	IEnumerator spawnOperations()
	{
		// keep spawning them every few seconds
		while (true) 
		{
			// generate random spawn point
			nextSpawner = Random.Range (1, spawners.Length);

			// generate random number for operations & operands
			int operationChance = Random.Range(0, 101);
			int operandChance = Random.Range (0, 101);

			// 50% chance to be + or -
			if (operationChance < 50) {
				nextOperation = Random.Range (19, 21);

				if (operandChance < 80) {
					nextOperand = Random.Range (1, 10);
				} else {
					nextOperand = Random.Range (10, 16);
				}
			
			// 20% chance to be x
			} else if (operationChance < 70) {
				nextOperation = 18;

				if (operandChance < 95) {
					nextOperand = Random.Range (2, 6);
				} else {
					nextOperand = Random.Range (6, 16);
				}

			// 20% chance to be /
			} else if (operationChance < 90) {
				nextOperation = 22;

				if (operandChance < 95) {
					nextOperand = Random.Range (2, 6);
				} else {
					nextOperand = Random.Range (6, 16);
				}

			// 10% chance to be =
			} else {
				nextOperation = 21;
				nextOperand = Random.Range (0, 16);
			}

			// determine spawn frequency factor based on sountrack BPM
			switch (LevelDifficulty.speed) {
			case 1:
				spawnFreqFactor = 0.5248f;
				break;
			case 2:
				spawnFreqFactor = 0.495f;
				break;
			case 3:
				spawnFreqFactor = 0.46153846f;
				break;
			case 4:
				spawnFreqFactor = 0.42857142857f;
				break;
			}
				
			yield return new WaitForSeconds ((float) (Random.Range(6,9) - LevelDifficulty.speed) * spawnFreqFactor);
			spawners [nextSpawner].GetComponent<Spawner> ().spawnOperation (nextOperation, nextOperand);
		}
	}
}
