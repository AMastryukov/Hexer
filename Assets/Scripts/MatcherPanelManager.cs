using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatcherPanelManager : MonoBehaviour {

	private Transform[] matcherNumbers;
	private GameObject numberPanelManager;
	private int difficulty;

	void Awake()
	{
		// get all numbers on the panel
		matcherNumbers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			matcherNumbers[i] = transform.GetChild (i);
		}

		numberPanelManager = GameObject.FindGameObjectWithTag ("NumberPanel");
	}

	public void SetDifficulty(int diff) {
		difficulty = diff;

		if (difficulty == 1) {
			matcherNumbers [0].gameObject.SetActive (false);
			matcherNumbers [1].gameObject.SetActive (false);
			matcherNumbers [2].gameObject.SetActive (true);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (false);
			matcherNumbers [5].gameObject.SetActive (false);
		} else if (difficulty == 2) {
			matcherNumbers [0].gameObject.SetActive (false);
			matcherNumbers [1].gameObject.SetActive (true);
			matcherNumbers [2].gameObject.SetActive (true);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (true);
			matcherNumbers [5].gameObject.SetActive (false);
		} else if (difficulty == 2) {
			matcherNumbers [0].gameObject.SetActive (true);
			matcherNumbers [1].gameObject.SetActive (true);
			matcherNumbers [2].gameObject.SetActive (true);
			matcherNumbers [3].gameObject.SetActive (true);
			matcherNumbers [4].gameObject.SetActive (true);
			matcherNumbers [5].gameObject.SetActive (true);
		}
	}

	public int GetDifficulty() {
		return difficulty;
	}

	// Use this for initialization
	void Start () {
		SetDifficulty (1);
	}
	
	// Update is called once per frame
	void Update () {
		if (difficulty == 3) {
			if (matcherNumbers [2].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[8].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [3].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[9].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [1].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[7].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [4].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[10].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [0].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[6].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [5].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[11].GetComponent<PanelNumber>().assignedNumber) {

			}
		}
		else if (difficulty == 2) {
			if (matcherNumbers [2].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[8].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [3].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[9].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [1].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[7].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [4].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[10].GetComponent<PanelNumber>().assignedNumber) {

			}
		}
		else if (difficulty == 1) {
			if (matcherNumbers [2].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[8].GetComponent<PanelNumber>().assignedNumber &&
				matcherNumbers [3].GetComponent<PanelNumber>().assignedNumber == numberPanelManager.GetComponent<NumberPanelManager>().getPanelNumbers()[9].GetComponent<PanelNumber>().assignedNumber) {
				GameObject.FindGameObjectWithTag ("CompleteLevel").GetComponent<CompleteLevel> ().EndLevel ();
			}
		}
	}
}
