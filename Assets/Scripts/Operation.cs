using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour 
{
	private int operatorSymbol;
	private int operandNumber;

	private Sprite[] symbolSprites;

	private GameObject operatorObject;
	private GameObject operandObject;

	private float stepDelaySeconds;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");

		operatorObject = this.transform.GetChild (0).gameObject;
		operandObject = this.transform.GetChild (1).gameObject;

		// default next-step delay is 1.0 seconds
		stepDelaySeconds = 1.0f;
	}

	// Use this for initialization
	void Start () 
	{
		StartCoroutine (moveDown());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("PanelNumber")) 
		{
			Destroy (gameObject);
		}
	}

	public void setOperator(int op)
	{
		operatorSymbol = op;
		operatorObject.GetComponent<SpriteRenderer>().sprite = symbolSprites[operatorSymbol];
	}

	public void setOperand(int op)
	{
		operandNumber = op;
		operandObject.gameObject.GetComponent<SpriteRenderer>().sprite = symbolSprites[operandNumber];
	}

	IEnumerator moveDown()
	{
		// keep moving the operation down to the bottom
		while (true) 
		{
			yield return new WaitForSeconds (stepDelaySeconds);
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z);
		}
	}


}
