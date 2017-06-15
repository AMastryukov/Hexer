using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapperButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			GameObject.Find ("PowerupManager").GetComponent<PowerupManager> ().swapNumbers ();
			Debug.Log ("PRESSED");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
