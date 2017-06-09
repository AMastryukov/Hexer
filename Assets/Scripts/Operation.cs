using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour 
{
	public AudioSource operationSound;
	public AudioSource operationDeleteSound;

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

		// get the step delay (same as spawn frequency of operations)
		stepDelaySeconds = GameObject.FindGameObjectWithTag("SpawnerController").GetComponent<SpawnerController>().spawnFreqFactor;
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
			AudioSource.PlayClipAtPoint (operationSound.clip, new Vector3(0,0,0));
			performOperation (operatorSymbol, operandNumber, other.gameObject.GetComponent<PanelNumber> ().panelIndex);
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
			transform.position = new Vector3 (transform.position.x, transform.position.y - (0.5f + LevelDifficulty.speed * 0.1f), transform.position.z);
		}
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			AudioSource.PlayClipAtPoint (operationDeleteSound.clip, new Vector3(0,0,0));
			Destroy (gameObject);
		}
	}

	// handle a given operation on a given number in the numberPanel
	void performOperation(int givenOperator, int givenOperand, int panelNumberIndex)
	{
		GameObject numberPanel = GameObject.FindGameObjectWithTag ("NumberPanel");
		GameObject currentPanelNumber = numberPanel.GetComponent<NumberPanelManager>().getPanelNumbers()[panelNumberIndex].gameObject;

		int newTotal = currentPanelNumber.GetComponent<PanelNumber> ().assignedNumber;

		// handle addition
		if (givenOperator == 19) {
			newTotal += givenOperand;
		}

		// handle subtraction
		if (givenOperator == 20) {
			newTotal -= givenOperand;

			// if it goes into the negatives, reset it back to 0
			if (newTotal < 0) {
				newTotal = 0;
			}
		}

		// handle multiplication
		if (givenOperator == 18) {
			newTotal = newTotal * givenOperand;
		}

		// handle division
		if (givenOperator == 22) {
			newTotal = newTotal / givenOperand;
		}

		// handle assignment
		if (givenOperator == 21) {
			newTotal = givenOperand;
		}
			
		currentPanelNumber.GetComponent<SpriteRenderer> ().sprite = symbolSprites [newTotal % 16];
		currentPanelNumber.GetComponent<PanelNumber> ().assignedNumber = newTotal % 16;

		newTotal = newTotal / 16;

		if (newTotal != 0 && panelNumberIndex != 0) {
			performOperation (19, newTotal, panelNumberIndex - 1);
		}
	}
}
