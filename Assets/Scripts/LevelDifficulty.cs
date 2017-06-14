using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDifficulty : MonoBehaviour {

	public static int difficulty = 1;
	public static int speed = 1;

	public GameObject[] levelLocks;
	public GameObject[] levelLocksPrice;
	public GameObject[] levelLoadButton;

	private static LevelDifficulty instance;

	// Use this for initialization
	void Start () {
		// handle speed slider value updating
		if (speed > 0 && GameObject.FindGameObjectWithTag ("SpeedSlider")) {
			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().onValueChanged.AddListener (delegate {
				instance.UpdateSpeedValue ();
			});
			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().onValueChanged.AddListener (delegate {
				GameObject.Find("DecalManager").GetComponent<DecalManager>().UpdateLevelInfoText();
			});
			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().onValueChanged.AddListener (delegate {
				instance.UpdateLevelLocks ();
			});

			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value = (float)speed;
		}

		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);
		} else if (instance != this) {
			instance.LoadLevelLockObjects ();
			instance.UpdateLevelLocks ();

			Destroy (this.gameObject);
			return;
		}

		LoadLevelLockObjects ();
		UpdateLevelLocks ();

		// handle speed slider value updating
		if (speed > 0 && GameObject.FindGameObjectWithTag ("SpeedSlider")) {
			GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value = (float)speed;
		}
	}

	public void UpdateSpeedValue() {
		speed = (int)GameObject.FindGameObjectWithTag ("SpeedSlider").GetComponent<Slider> ().value;
	}

	public void LoadLevelLockObjects() {
		for (int i = 0; i < 4; i++) {
			levelLocks [i] = GameObject.Find ("Lock " + (i + 1));
			levelLocksPrice [i] = GameObject.Find ("LockPrice" + (i + 1));
			levelLoadButton [i] = GameObject.Find ("Difficulty " + (i + 1));
		}
	}

	public void UpdateLevelLocks() {
		for (int i = 0; i < 4; i++) {
			if (StatisticsTracker.levelUnlocks [i, speed - 1]) {
				levelLocks [i].SetActive (false);
				levelLocksPrice [i].SetActive (false);
				levelLoadButton [i].SetActive (true);
			} else {
				levelLocks [i].SetActive (true);
				levelLocksPrice [i].SetActive (true);
				levelLocksPrice [i].GetComponent<Text> ().text = StatisticsTracker.getLevelUnlockCost(i + 1, speed) + " bits";
				levelLoadButton [i].SetActive (false);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void StartLevel() {
		StatisticsTracker.replenishDeletePowerups ();
		SceneManager.LoadScene ("GameScene");
	}
}