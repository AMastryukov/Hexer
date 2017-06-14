using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoutButton : MonoBehaviour {

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
			gameObject.GetComponent<Text> ().text = "[LOGGING OUT IN " + (Mathf.Round ((1 - Time.time + holdDelay) * 10f) / 10f) + "...]";

			if ((Time.time - holdDelay > 1f) && overButton) {
				SaveLoadData.Save ();
				Application.Quit ();
			}
		} else {
			gameObject.GetComponent<Text> ().text = "[LOG OUT]";
		}
	}
}
