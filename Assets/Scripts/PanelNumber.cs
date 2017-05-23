using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelNumber : MonoBehaviour 
{
	private Sprite[] symbolSprites;
	private int assignedNumber;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
		assignedNumber = Random.Range (0, 15);
	}

	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = symbolSprites[assignedNumber];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}