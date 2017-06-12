using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupBarText : MonoBehaviour {

	Text powerupBarText;

	// Use this for initialization
	void Start () {
		powerupBarText = GameObject.Find ("PowerupBarText").GetComponent<Text> ();
	}

	public void UpdatePowerupBarText() {
		powerupBarText.text = " ";
		powerupBarText.text += StatisticsTracker.getAvailableDeletePowerups ();
		powerupBarText.text += "/";
		powerupBarText.text += StatisticsTracker.getMaxDeletePowerups ();
		powerupBarText.text += " deleters | ";
		powerupBarText.text += StatisticsTracker.getAssignmentPowerups ();
		powerupBarText.text += " duplicators | ";
		powerupBarText.text += StatisticsTracker.getSwapPowerups();
		powerupBarText.text += " swappers | ";
		powerupBarText.text += StatisticsTracker.getRandomizePowerups ();
		powerupBarText.text += " scramblers";
	}
	
	// Update is called once per frame
	void Update () {
		UpdatePowerupBarText ();
	}
}
