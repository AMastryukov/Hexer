using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbandonLevel : MonoBehaviour {

	float holdDelay;
	bool overButton = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			overButton = true;
		}
	}

	void OnMouseExit() {
		overButton = false;
		holdDelay = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && overButton) {
			holdDelay = Time.time;
		}

		if (Input.GetMouseButton (0) && overButton) {
			gameObject.GetComponent<Text> ().text = "(" + (Mathf.Round ((1 - Time.time + holdDelay) * 10f) / 10f) + ") ABANDON";

			if ((Time.time - holdDelay > 1f) && overButton) {
				GameObject.Find ("SoundTrack").GetComponent<Soundtrack> ().StopMusic ();
				GameObject.FindGameObjectWithTag ("CompleteLevel").GetComponent<CompleteLevel> ().EndLevel ();

				gameObject.GetComponent<Text> ().text = "GAME OVER";
				gameObject.GetComponent<AbandonLevel> ().enabled = false;
			}
		} else {
			gameObject.GetComponent<Text> ().text = "ABANDON";
		}
	}
}
