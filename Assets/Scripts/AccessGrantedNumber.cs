using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessGrantedNumber : MonoBehaviour {

	public int letter;
	private Sprite[] symbolSprites;
	private int[] possibleLetters = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,23,24,25,26,27};

	void Awake()
	{
		symbolSprites = Resources.LoadAll<Sprite>("Sprites/symbols");
	}

	// Use this for initialization
	void Start () {
		
	}

	public void Animate(int iterations) {
		StartCoroutine (RandomizeNumbers (iterations));
	}

	IEnumerator RandomizeNumbers(int iterations)
	{
		// keep the randomization going
		for (int i = 0; i < iterations; i++) 
		{
			yield return new WaitForSeconds (0.05f);
			gameObject.GetComponent<SpriteRenderer> ().sprite = symbolSprites [possibleLetters[Random.Range (0,possibleLetters.Length)]];
		}

		//assign the final letter
		gameObject.GetComponent<SpriteRenderer> ().sprite = symbolSprites [letter];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
