using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour {

	GameObject spawnerController;
	GameObject numberShifter;
	GameObject matcherPanel;
	GameObject[] matcherNumbers;
	GameObject[] panelNumbers;
	GameObject[] operations;
	GameObject[] arrows;

	string endLevelTextString;
	string endLevelStatsString;

	// Use this for initialization
	void Start () {
		
	}

	public void EndLevel() {
		DisableScripts ();
		DropObjectsDown ();
		DisplayAccessGrantedText ();

		DisplayLevelStats ();
	}

	void DisableScripts() {
		DisableMatcher ();
		DisableOperations ();
		DisableSpawners ();
		DisableNumberShifter ();
		DisableAbandonButton ();
	}

	void DisableMatcher() {
		matcherPanel = GameObject.FindGameObjectWithTag ("MatcherPanel");
		matcherPanel.gameObject.GetComponent<MatcherPanelManager> ().enabled = false;
	}

	void DisableOperations() {
		operations = GameObject.FindGameObjectsWithTag ("Operation");

		for (int i = 0; i < operations.Length; i++) {
			Destroy(operations [i].gameObject.GetComponent<Operation> ());
		}
	}

	void DisableSpawners() {
		spawnerController = GameObject.FindGameObjectWithTag ("SpawnerController");
		Destroy (spawnerController.gameObject.GetComponent<SpawnerController>());
	}

	void DisableNumberShifter() {
		numberShifter = GameObject.FindGameObjectWithTag ("NumberShifter");
		Destroy (numberShifter.gameObject.GetComponent<NumberShifter> ());
	}

	void DisableAbandonButton() {
		GameObject.Find ("Abandon").GetComponent<Text> ().text = "GAME OVER";
		GameObject.Find ("Abandon").GetComponent<AbandonLevel> ().enabled = false;
	}

	void DropObjectsDown() {
		// drop panel numbers
		panelNumbers = GameObject.FindGameObjectsWithTag ("PanelNumber");
		for (int i = 0; i < panelNumbers.Length; i++) {
			panelNumbers [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (1.0f, 2.0f);
			panelNumbers [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (panelNumbers [i].gameObject, 4);
		}

		// drop matcher numbers
		matcherNumbers = GameObject.FindGameObjectsWithTag ("MatcherNumber");
		for (int i = 0; i < matcherNumbers.Length; i++) {
			matcherNumbers [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (1.0f, 2.0f);
			matcherNumbers [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (matcherNumbers [i].gameObject, 4);
		}

		// drop operations
		operations = GameObject.FindGameObjectsWithTag ("Operation");
		for (int i = 0; i < operations.Length; i++) {
			operations [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (1.0f, 2.0f);
			operations [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (operations [i].gameObject, 4);
		}

		// drop arrows
		arrows = GameObject.FindGameObjectsWithTag ("Arrow");
		for (int i = 0; i < arrows.Length; i++) {
			arrows [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (1.0f, 2.0f);
			arrows [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (arrows [i].gameObject, 4);
		}
	}

	void DisplayAccessGrantedText () {
		GameObject[] accessGrantedText = GameObject.FindGameObjectsWithTag ("AccessGrantedLetter");

		for (int i = 0; i < accessGrantedText.Length; i++) {
			accessGrantedText [i].GetComponent<AccessGrantedNumber> ().Animate (Random.Range(10,30));
			accessGrantedText [i].GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void DisplayLevelStats() {
		GameObject endLevelText = GameObject.Find ("EndLevelText");
		GameObject endLevelStats = GameObject.Find ("EndLevelStats");

		endLevelText.GetComponent<Text> ().text = "";
		endLevelText.GetComponent<Text> ().enabled = true;

		endLevelStats.GetComponent<Text> ().text = "";
		endLevelStats.GetComponent<Text> ().enabled = true;

		StartCoroutine (AnimateEndLevelStatsText(endLevelText, endLevelStats));
	}

	IEnumerator AnimateEndLevelStatsText(GameObject endLevelText, GameObject endLevelStats) {
		int baseBits = 16;
		int levelMuliplier = (2 * LevelDifficulty.difficulty) + 2;
		int speedMultiplier = LevelDifficulty.speed;
		int operationBonus = (int)((StatisticsTracker.levelStats [0] +
		                     StatisticsTracker.levelStats [1] +
		                     StatisticsTracker.levelStats [2] +
		                     StatisticsTracker.levelStats [3] +
		                     StatisticsTracker.levelStats [4]) / 4);
		int totalBits = baseBits * levelMuliplier * speedMultiplier + operationBonus;

		endLevelText.GetComponent<Text>().text = "";
		endLevelStats.GetComponent<Text>().text = "";

		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n";
		endLevelStats.GetComponent<Text>().text += "\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Additions:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [0] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Subtractions:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [1] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Multiplications:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [2] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Divisions:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [3] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Assignments\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [4] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n";
		endLevelStats.GetComponent<Text>().text += "\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Total operations performed:\n";
		endLevelStats.GetComponent<Text>().text += 
			StatisticsTracker.levelStats [0] + 
			StatisticsTracker.levelStats [1] + 
			StatisticsTracker.levelStats [2] + 
			StatisticsTracker.levelStats [3] + 
			StatisticsTracker.levelStats [4] + "|\n";
		
		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n";
		endLevelStats.GetComponent<Text>().text += "\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Deletions:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [5] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Duplications:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [6] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Swaps:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [7] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Scrambles:\n";
		endLevelStats.GetComponent<Text>().text += StatisticsTracker.levelStats [8] + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n";
		endLevelStats.GetComponent<Text>().text += "\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "Total powerups used:\n";
		endLevelStats.GetComponent<Text>().text += 
			StatisticsTracker.levelStats [5] + 
			StatisticsTracker.levelStats [6] + 
			StatisticsTracker.levelStats [7] + 
			StatisticsTracker.levelStats [8] + "|\n";
		
		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n";
		endLevelStats.GetComponent<Text>().text += "\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Base bits:\n";
		endLevelStats.GetComponent<Text>().text += baseBits + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Level multiplier:\n";
		endLevelStats.GetComponent<Text>().text += "x" + levelMuliplier + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Speed multiplier:\n";
		endLevelStats.GetComponent<Text>().text += "x" + speedMultiplier + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Operation bonus:\n";
		endLevelStats.GetComponent<Text>().text += "+" + 
			(int)((StatisticsTracker.levelStats [0] + 
			StatisticsTracker.levelStats [1] + 
			StatisticsTracker.levelStats [2] + 
			StatisticsTracker.levelStats [3] + 
				StatisticsTracker.levelStats [4]) / 4) + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n";
		endLevelStats.GetComponent<Text>().text += "\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "|Total bits earned:\n";
		endLevelStats.GetComponent<Text>().text += totalBits + "|\n";

		yield return new WaitForSeconds (0.1f);
		endLevelText.GetComponent<Text>().text += "-----------------------------------------------------\n  ";

		// update values for statistics (bits and achievements)
		StatisticsTracker.addBits(totalBits);
		StatisticsTracker.updateOverallStats ();

		yield return new WaitForSeconds (1.0f);
		endLevelStats.GetComponent<Text>().text += "\n";
		endLevelStats.GetComponent<Text>().text += "<Continue>";

		// enable the continue button
		GameObject.Find ("EndLevelStats").GetComponent<BoxCollider2D> ().enabled = true;
		GameObject.Find ("EndLevelStats").GetComponent<EndLevel> ().enabled = true;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
