using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

	public bool gamePaused = false;

	GameObject numberShifter;
	GameObject abandonButton;
	GameObject powerupManager;

	// Use this for initialization
	void Start () {
		numberShifter = GameObject.Find ("NumberShifter");
		abandonButton = GameObject.Find ("Abandon");
		powerupManager = GameObject.Find ("PowerupManager");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			gamePaused = !gamePaused;
		}

		if (gamePaused) {
			gameObject.GetComponent<Text> ().enabled = true;
			numberShifter.SetActive (false);
			abandonButton.GetComponent<BoxCollider2D>().enabled = false;
			powerupManager.SetActive (false);

			Time.timeScale = 0.0f;
		} else {
			gameObject.GetComponent<Text> ().enabled = false;
			numberShifter.SetActive (true);
			abandonButton.GetComponent<BoxCollider2D>().enabled = true;
			powerupManager.SetActive (true);

			Time.timeScale = 1.0f;
		}
	}
}
