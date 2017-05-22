using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymbolAssigner : MonoBehaviour {

	public Sprite[] symbolSprites;

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
	}

	// Use this for initialization
	void Start () 
	{
		this.gameObject.GetComponent<SpriteRenderer>().sprite = symbolSprites[Random.Range(0,15)];
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
