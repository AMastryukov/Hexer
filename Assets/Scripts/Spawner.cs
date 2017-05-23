using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour 
{
	private Sprite[] symbolSprites;
	public GameObject operation;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	// Spawn an operation given operator and operand
	public void spawnOperation(int givenOperator, int givenOperand)
	{
		Vector3 position = transform.position;
		position.y = position.y - 1;

		// Instantiate a new operation with given operator and operand
		GameObject newOperation = Instantiate (operation, position, transform.rotation);

		newOperation.GetComponent<Operation>().setOperator (givenOperator);
		newOperation.GetComponent<Operation>().setOperand (givenOperand);
	}
}