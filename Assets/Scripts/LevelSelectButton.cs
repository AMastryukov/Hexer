using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour {

	public int difficulty = 1;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.9f,0.9f,0.9f);
		gameObject.GetComponent<Transform> ().localScale = new Vector3 (1.9f,1.9f,1.9f);

		LevelDifficulty.difficulty = difficulty;
		GameObject.Find ("DecalManager").GetComponent<DecalManager> ().UpdateLevelInfoText ();

		if (Input.GetMouseButtonDown(0)) {
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.4f,0.4f,0.4f);

			LevelDifficulty.StartLevel ();
		}
	}

	void OnMouseExit() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f,1f,1f);
		gameObject.GetComponent<Transform> ().localScale = new Vector3 (2f,2f,2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
