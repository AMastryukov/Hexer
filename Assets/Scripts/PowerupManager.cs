using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour {

	public AudioSource powerupSound;

	// Use this for initialization
	void Start () {
		
	}

	public void createDuplicateAssignment(int value) {
		if (StatisticsTracker.removeAssignmentPowerup ()) {
			GameObject.Find ("SpawnerController").GetComponent<SpawnerController> ().SetNextOperation (21, value);
			powerupSound.volume = Soundtrack.volume;
			powerupSound.Play ();

			StatisticsTracker.levelStats [6]++;
		}
	}

	public bool deleteOperation () {
		if (StatisticsTracker.removeAvailableDeletePowerup ()) {
			powerupSound.volume = Soundtrack.volume;
			powerupSound.Play ();

			StatisticsTracker.levelStats [5]++;

			return true;
		} else {
			return false;
		}
	}

	public void swapNumbers() {
		if (StatisticsTracker.removeSwapPowerup ()) {
			GameObject.Find ("SpawnerController").GetComponent<SpawnerController> ().SetNextOperation (16, 17);
			powerupSound.Play ();

			StatisticsTracker.levelStats [7]++;
		}
	}

	public void scrambleNumbers() {
		if (StatisticsTracker.removeRandomizePowerup ()) {
			GameObject.Find ("SpawnerController").GetComponent<SpawnerController> ().SetNextOperation (21, 28);
			powerupSound.Play ();

			StatisticsTracker.levelStats [8]++;
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
