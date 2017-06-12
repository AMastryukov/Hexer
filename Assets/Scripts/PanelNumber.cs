using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNumber : MonoBehaviour 
{
	private Sprite[] symbolSprites;
	public int assignedNumber;
	public int panelIndex;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
		assignedNumber = Random.Range (0, 15);
	}

	// Use this for initialization
	void Start () 
	{
		UpdateSprite ();
	}

	public void SetAssignedNumber(int number) {
		assignedNumber = number;
		UpdateSprite ();
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			if (gameObject.tag == "PanelNumber") {
				GameObject.Find("PowerupManager").GetComponent<PowerupManager>().createDuplicateAssignment (assignedNumber);
			}
		}
	}

	public void UpdateSprite() {
		this.gameObject.GetComponent<SpriteRenderer>().sprite = symbolSprites[assignedNumber];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}