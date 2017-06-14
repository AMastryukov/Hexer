using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenStatsButton : MonoBehaviour {

	private bool toggle = false;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			if (toggle) {
				GameObject.Find ("AllStatsText").GetComponent<Text>().enabled = false;
				GameObject.Find ("AllStats").GetComponent<Text>().enabled = false;

				toggle = false;
			} else {
				GameObject.Find ("AllStatsText").GetComponent<Text>().enabled = true;
				GameObject.Find ("AllStats").GetComponent<Text>().enabled = true;

				GameObject.Find ("AllStats").GetComponent<Text> ().text = "";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[0] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[1] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[2] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[3] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[4] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += 
					StatisticsTracker.overallStats[0] + 
					StatisticsTracker.overallStats[1] +
					StatisticsTracker.overallStats[2] +
					StatisticsTracker.overallStats[3] +
					StatisticsTracker.overallStats[4] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[5] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[6] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[7] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += StatisticsTracker.overallStats[8] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text +=  
					StatisticsTracker.overallStats[5] + 
					StatisticsTracker.overallStats[6] +
					StatisticsTracker.overallStats[7] +
					StatisticsTracker.overallStats[8] + "|\n";
				GameObject.Find ("AllStats").GetComponent<Text> ().text += "\n";

				toggle = true;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
