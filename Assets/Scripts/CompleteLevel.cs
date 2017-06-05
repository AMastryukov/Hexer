using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour {

	GameObject spawnerController;
	GameObject numberShifter;
	GameObject matcherPanel;
	GameObject[] matcherNumbers;
	GameObject[] panelNumbers;
	GameObject[] operations;
	GameObject[] arrows;

	// Use this for initialization
	void Start () {
		
	}

	public void EndLevel() {
		DisableScripts ();
		DropObjectsDown ();
		DisplayAccessGrantedText ();
	}

	void DisableScripts() {
		DisableMatcher ();
		DisableOperations ();
		DisableSpawners ();
		DisableNumberShifter ();
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

	void DropObjectsDown() {
		// drop panel numbers
		panelNumbers = GameObject.FindGameObjectsWithTag ("PanelNumber");
		for (int i = 0; i < panelNumbers.Length; i++) {
			panelNumbers [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (0.5f, 2.0f);
			panelNumbers [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (panelNumbers [i].gameObject, 4);
		}

		// drop matcher numbers
		matcherNumbers = GameObject.FindGameObjectsWithTag ("MatcherNumber");
		for (int i = 0; i < matcherNumbers.Length; i++) {
			matcherNumbers [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (0.5f, 2.0f);
			matcherNumbers [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (matcherNumbers [i].gameObject, 4);
		}

		// drop operations
		operations = GameObject.FindGameObjectsWithTag ("Operation");
		for (int i = 0; i < operations.Length; i++) {
			operations [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (0.5f, 2.0f);
			operations [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (operations [i].gameObject, 4);
		}

		// drop arrows
		arrows = GameObject.FindGameObjectsWithTag ("Arrow");
		Debug.Log (arrows.Length);
		for (int i = 0; i < operations.Length; i++) {
			arrows [i].gameObject.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (0.5f, 2.0f);
			arrows [i].gameObject.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;

			Destroy (arrows [i].gameObject, 4);
		}
	}

	void DisplayAccessGrantedText () {
		GameObject[] accessGrantedText = GameObject.FindGameObjectsWithTag ("AccessGrantedLetter");

		for (int i = 0; i < accessGrantedText.Length; i++) {
			accessGrantedText [i].GetComponent<AccessGrantedNumber> ().Animate (Random.Range(20,40));
			accessGrantedText [i].GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
