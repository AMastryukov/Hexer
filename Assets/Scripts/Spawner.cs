using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	private Sprite[] symbolSprites;

	private int assignedOperator;
	private int assignedOperand;
	public GameObject operation;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
	}

	// Use this for initialization
	void Start () 
	{
		spawnOperation (0,0);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Spawn an operation given operator and operand
	public void spawnOperation(int givenOperator, int givenOperand)
	{
		assignedOperator = givenOperator;
		assignedOperand = givenOperand;

		Vector3 position = transform.position;
		position.y = position.y - 2;

		Instantiate (operation, position, transform.rotation);
	}
}