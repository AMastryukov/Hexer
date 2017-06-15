using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNumber : MonoBehaviour 
{
	private Sprite[] symbolSprites;
	public int assignedNumber;
	public int panelIndex;

	GameObject pauseGame;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
		assignedNumber = Random.Range (0, 15);
	}

	// Use this for initialization
	void Start () 
	{
		UpdateSprite ();
		pauseGame = GameObject.Find ("PauseGame");
	}

	public void SetAssignedNumber(int number) {
		assignedNumber = number;
		UpdateSprite ();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0) && !pauseGame.GetComponent<PauseGame>().gamePaused) {
			if (gameObject.tag == "PanelNumber") {
				GameObject.Find("PowerupManager").GetComponent<PowerupManager>().createDuplicateAssignment (assignedNumber);
			}
		}
	}

	public void UpdateSprite() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = symbolSprites[assignedNumber];

		// make the color brighter if it is one of the matcher panel numbers
		GameObject[] matcherPanelNumbers = GameObject.FindGameObjectsWithTag ("MatcherNumber");

		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.7f, 0.7f, 0.7f);

		for (int i = 0; i < matcherPanelNumbers.Length; i++) {
			if (matcherPanelNumbers [i].GetComponent<PanelNumber> ().assignedNumber == assignedNumber) {
				gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateSprite ();
	}
}