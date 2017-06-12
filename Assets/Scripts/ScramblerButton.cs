using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScramblerButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			GameObject.Find ("PowerupManager").GetComponent<PowerupManager> ().scrambleNumbers ();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
