using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDifficulty : MonoBehaviour {

	public static int difficulty = 1;
	public static int speed = 1;

	private static LevelDifficulty instance;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else if (instance != this) {
			Destroy (this.gameObject);
			return;
		}

		// handle speed slider value updating
		if (speed > 0 && GameObject.FindGameObjectWithTag ("SpeedSlider")) {
			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value = (float)speed;
		}
	}

	public void UpdateSpeedValue() {
		speed = (int)GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value;
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "MainMenuScene") {
			UpdateSpeedValue ();
		}
	}

	public static void StartLevel() {
		StatisticsTracker.replenishDeletePowerups ();
		SceneManager.LoadScene ("GameScene");
	}

}
