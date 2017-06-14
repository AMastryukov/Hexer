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
		if (Input.GetMouseButtonDown(0)) {

			StartCoroutine (SaveGame ());
		}
	}

	IEnumerator SaveGame() {
		SaveLoadData.Save ();

		savedLoadedText.text = "Game Saved";
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;

		yield return new WaitForSeconds (2);

		savedLoadedText.text = "";
		gameObject.GetComponent<SpriteRenderer> ().enabled = true;
		gameObject.GetComponent<BoxCollider2D> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
