using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveGameButton : MonoBehaviour {

	Text savedLoadedText;

	// Use this for initialization
	void Start () {
		savedLoadedText = GameObject.Find ("GameSavedText").GetComponent<Text>();
		savedLoadedText.text = "";
	}

	void OnMouseOver() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.9f,0.9f,0.9f);
		gameObject.GetComponent<Transform> ().localScale = new Vector3 (0.73f,0.73f,0.73f);

		if (Input.GetMouseButtonDown(0)) {
			SaveLoadData.Save ();
			StartCoroutine (DisplaySavedText ());
		}
	}

	void OnMouseExit() {
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1.0f,1.0f,1.0f);
		gameObject.GetComponent<Transform> ().localScale = new Vector3 (0.75f,0.75f,0.75f);
	}

	IEnumerator DisplaySavedText() {
		savedLoadedText.text = "Game Saved";
		yield return new WaitForSeconds (3);
		savedLoadedText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
