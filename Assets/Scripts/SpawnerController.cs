using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	private Transform[] spawners;

	private int nextSpawner;
	private int nextOperation;
	private int nextOperand;

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
			nextSpawner = Random.Range (1, 13);

			// generate number
			int numberGenChance = Random.Range(0,100);

			if (numberGenChance < 70) {
				nextOperand = Random.Range (0, 8);
			} else if (numberGenChance < 90) {
				nextOperand = Random.Range (8, 12);
			} else {
				nextOperand = Random.Range (12, 16);
			}

			// generate operation
			int operationGenChance = Random.Range(0,100);
			int[] multAndDivIndeces = {18,22};

			if (operationGenChance < 75) {
				nextOperation = Random.Range (19, 21);
			} else if (operationGenChance < 90) {
				nextOperation = multAndDivIndeces [Random.Range (0, 2)];
			} else {
				nextOperation = 21;
			}

			// if the operand is 0, then avoid division, additon and subtraction
			if (nextOperand == 0) {
				while (nextOperation == 19 || nextOperation == 20 || nextOperation == 22) {
					nextOperation = Random.Range (18, 23);
				}
			}

			// if the operand is 1, avoid multiplication and division
			if (nextOperand == 1) {
				while (nextOperation == 18 || nextOperation == 22) {
					nextOperation = Random.Range (18, 23);
				}
			}
				
			yield return new WaitForSeconds ((float) Random.Range(0.5f,4.0f));
			spawners [nextSpawner].GetComponent<Spawner> ().spawnOperation (nextOperation, nextOperand);
		}
	}
}
