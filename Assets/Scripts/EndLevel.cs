using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			SceneManager.LoadScene ("MainMenuScene");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
