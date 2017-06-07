using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStartButton : MonoBehaviour {

	public int difficulty = 1;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			LevelDifficulty.difficulty = difficulty;
			LevelDifficulty.StartLevel ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
