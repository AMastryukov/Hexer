using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DecalManager : MonoBehaviour {

	Text topText;
	Text levelInfoText;
	Text statText;

	Sprite[] levelDecals;

	// Use this for initialization
	void Start () {
		topText = GameObject.Find ("TopText").GetComponent<Text> ();
		levelInfoText = GameObject.Find ("LevelInfoText").GetComponent<Text> ();
		statText = GameObject.Find ("Stats").GetComponent<Text> ();

		StartCoroutine (UpdateMainMenuTopText ());
		UpdateLevelInfoText ();
	}

	IEnumerator UpdateMainMenuTopText() {
		while (true) {
			topText.text = "";
			topText.text += "Processes: " + Random.Range (1, 3) + " total, 1 active, " + Random.Range(300,330) + " threads\n";
			topText.text += "CPU Usage: " + Mathf.Round(Random.Range (5.0f, 10.0f) * 100f) / 100f  + "% user, " + Mathf.Round(Random.Range (5.0f, 10.0f) * 100f) / 100f  + "% sys" + "\n";
			topText.text += "MEM Usage: " + Mathf.Round(Random.Range (8.0f, 20.0f) * 100f) / 100f  + "%\n";
			topText.text += "IP: " + Random.Range(0, 256) + "." + Random.Range(0, 256) + "." + Random.Range(0, 256) + "." + Random.Range(0, 256) + "\n";

			yield return new WaitForSeconds (1.04347826f);
		}
	}

	public void UpdateLevelInfoText() {
		levelInfoText.text = "";
		levelInfoText.text += "[Access ";

		switch (LevelDifficulty.difficulty) {
			case 1: 
				levelInfoText.text += "local school ";
				break;
			case 2:
				levelInfoText.text += "police station ";
				break;
			case 3:
				levelInfoText.text += "MyFace servers ";
				break;
			case 4:
				levelInfoText.text += "NSA records ";
				break;
		}

		levelInfoText.text += "and retrieve ";

		switch (LevelDifficulty.speed) {
			case 1:
				levelInfoText.text += "public data";
				break;
			case 2:
				levelInfoText.text += "hidden data";
				break;
			case 3:
				levelInfoText.text += "encrypted data";
				break;
			case 4:
				levelInfoText.text += "highly classified data";
				break;
		}

		levelInfoText.text += "]";
	}

	public void UpdateStatsText() {
		statText.text = "";
		statText.text += StatisticsTracker.getAvailableBits ();
		statText.text += " bits available\n\n";
		statText.text += StatisticsTracker.getMaxDeletePowerups ();
		statText.text += " deleters (" + StatisticsTracker.getDeletePowerupCost() + " bits) [+]\n";
		statText.text += StatisticsTracker.getAssignmentPowerups ();
		statText.text += " duplicators (64 bits) [+]\n";
		statText.text += StatisticsTracker.getSwapPowerups();
		statText.text += " swappers (32 bits) [+]\n";
		statText.text += StatisticsTracker.getRandomizePowerups ();
		statText.text += " scramblers (16 bits) [+]\n";
	}
	
	// Update is called once per frame
	void Update () {
		UpdateStatsText ();
	}
}
