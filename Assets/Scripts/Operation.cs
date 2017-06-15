using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Operation : MonoBehaviour 
{
	public AudioSource operationSound;

	private int operatorSymbol;
	private int operandNumber;

	private Sprite[] symbolSprites;

	private GameObject operatorObject;
	private GameObject operandObject;

	private float stepDelaySeconds;

	GameObject pauseGame;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");

		operatorObject = this.transform.GetChild (0).gameObject;
		operandObject = this.transform.GetChild (1).gameObject;

		pauseGame = GameObject.Find ("PauseGame");

		operationSound.volume = Soundtrack.volume;

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
			yield return new WaitForSeconds (stepDelaySeconds / 2);
			transform.position = new Vector3 (transform.position.x, transform.position.y - (0.15f + LevelDifficulty.speed * 0.03f), transform.position.z);
		}
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0) && !pauseGame.GetComponent<PauseGame>().gamePaused) {
			if (GameObject.Find("PowerupManager").GetComponent<PowerupManager>().deleteOperation ()) {
				Destroy (gameObject);
			}
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

			StatisticsTracker.levelStats [0]++;
		}

		// handle subtraction
		if (givenOperator == 20) {
			newTotal -= givenOperand;

			// if it goes into the negatives, reset it back to 0
			if (newTotal < 0) {
				newTotal = 0;
			}

			StatisticsTracker.levelStats [1]++;
		}

		// handle multiplication
		if (givenOperator == 18) {
			newTotal = newTotal * givenOperand;

			StatisticsTracker.levelStats [2]++;
		}

		// handle division
		if (givenOperator == 22) {
			newTotal = newTotal / givenOperand;

			StatisticsTracker.levelStats [3]++;
		}

		// handle assignment
		if (givenOperator == 21) {
			newTotal = givenOperand;

			// if operand is ?, randomize the number
			if (givenOperand == 28) {
				newTotal = Random.Range (0, 16);
			} else {
				StatisticsTracker.levelStats [4]++;
			}
		}
			
		// swap powerup
		if (givenOperator == 16) {
			int tempTotal = numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [panelNumberIndex].GetComponent<PanelNumber> ().assignedNumber;

			// swap the previous and current numbers
			newTotal = numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [panelNumberIndex - 1].GetComponent<PanelNumber> ().assignedNumber;
			numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [panelNumberIndex - 1].GetComponent<PanelNumber> ().SetAssignedNumber(tempTotal);

			StatisticsTracker.levelStats [7]++;
		}
			
		currentPanelNumber.GetComponent<SpriteRenderer> ().sprite = symbolSprites [newTotal % 16];
		currentPanelNumber.GetComponent<PanelNumber> ().assignedNumber = newTotal % 16;

		newTotal = newTotal / 16;

		if (newTotal != 0 && panelNumberIndex != 0) {
			performOperation (19, newTotal, panelNumberIndex - 1);
		}
	}
}
