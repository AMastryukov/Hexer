using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbandonLevel : MonoBehaviour {

	float holdDelay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			holdDelay = Time.time;
		}

		if (Input.GetMouseButton (0)) {
			gameObject.GetComponent<Text> ().text = "(" + (Mathf.Round ((2 - Time.time + holdDelay) * 10f) / 10f) + ") ABANDON";

			if (Time.time - holdDelay > 2f) {
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
