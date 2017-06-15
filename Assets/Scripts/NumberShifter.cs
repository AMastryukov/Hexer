using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberShifter : MonoBehaviour {

	public AudioSource sound;

	GameObject numberPanel;
	int tempNumber;
	int lastPanelIndex;

	float leftKeyDelay;
	float rightKeyDelay;

	void Awake() {
		
	}

	// Use this for initialization
	void Start () {
		numberPanel = GameObject.FindGameObjectWithTag ("NumberPanel");
		lastPanelIndex = numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers ().Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			// for determining hold delay
			leftKeyDelay = Time.time;
			ShiftNumbersLeft ();
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (Time.time - leftKeyDelay > 0.5f) {
				ShiftNumbersLeft ();
			}
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			// for determining hold delay
			rightKeyDelay = Time.time;
			ShiftNumbersRight ();
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (Time.time - rightKeyDelay > 0.5f) {
				ShiftNumbersRight ();
			}
		}

		sound.volume = Soundtrack.volume;
	}


	void ShiftNumbersLeft() {
		tempNumber = numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [0].gameObject.GetComponent<PanelNumber> ().assignedNumber;

		// shift the numbers to the left and update the sprites
		for (int i = 0; i < lastPanelIndex; i++) {
			numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [i].GetComponent<PanelNumber> ().SetAssignedNumber(
				numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [i+1].GetComponent<PanelNumber> ().assignedNumber);
		}

		numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [lastPanelIndex].GetComponent<PanelNumber> ().SetAssignedNumber(tempNumber);

		// play sound
		sound.Play();
	}

	void ShiftNumbersRight() {
		tempNumber = numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [lastPanelIndex].gameObject.GetComponent<PanelNumber> ().assignedNumber;

		// shift the numbers to the right and update the sprites
		for (int i = lastPanelIndex; i > 0; i--) {
			numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [i].GetComponent<PanelNumber> ().SetAssignedNumber(
				numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [i - 1].GetComponent<PanelNumber> ().assignedNumber);
		}

		numberPanel.GetComponent<NumberPanelManager> ().getPanelNumbers () [0].GetComponent<PanelNumber> ().SetAssignedNumber(tempNumber);

		// play sound
		sound.Play();
	}
}
