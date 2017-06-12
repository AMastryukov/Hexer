using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsTracker : MonoBehaviour {

	// available bits to spend
	static int availableBits;

	// available assignment and swap operation powerups
	static int assignmentPowerups;
	static int swapPowerups;
	static int randomizePowerups;

	// delete powerups have a maximum value and replenish every level
	static int maxDeletePowerups;
	static int availableDeletePowerups;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (transform.gameObject);

		availableBits = 64;

		assignmentPowerups = 0;
		swapPowerups = 0;
		randomizePowerups = 0;
		maxDeletePowerups = 0;
		availableDeletePowerups = 0;
	}

	// GETTERS
	public static int getAvailableBits() {
		return availableBits;
	}
		
	public static int getAssignmentPowerups() {
		return assignmentPowerups;
	}

	public static int getSwapPowerups() {
		return swapPowerups;
	}

	public static int getRandomizePowerups() {
		return randomizePowerups;
	}

	public static int getDeletePowerupCost() {
		return (int)Mathf.Pow(2, (maxDeletePowerups + 3));
	}

	public static int getMaxDeletePowerups() {
		return maxDeletePowerups;
	}

	public static int getAvailableDeletePowerups() {
		return availableDeletePowerups;
	}

	// ADDERS
	public static void addBits(int bits) {
		availableBits += bits;
	}

	public static void addAssignmentPowerup() {
		assignmentPowerups++;
	}

	public static void addSwapPowerup() {
		swapPowerups++;
	}

	public static void addRandomizePowerup() {
		randomizePowerups++;
	}

	public static void addMaxDeletePowerup() {
		maxDeletePowerups++;
	}

	// REMOVERS
	public static bool removeBits(int bits) {
		if (availableBits >= bits) {
			availableBits -= bits;
			return true;
		} else {
			return false;
		}
	}

	public static bool removeAssignmentPowerup() {
		if (assignmentPowerups > 0) {
			assignmentPowerups--;
			return true;
		} else {
			return false;
		}
	}

	public static bool removeSwapPowerup() {
		if (swapPowerups > 0) {
			swapPowerups--;
			return true;
		} else {
			return false;
		}
	}

	public static bool removeRandomizePowerup() {
		if (randomizePowerups > 0) {
			randomizePowerups--;
			return true;
		} else {
			return false;
		}
	}

	public static bool removeAvailableDeletePowerup() {
		if (availableDeletePowerups > 0) {
			availableDeletePowerups--;
			return true;
		} else {
			return false;
		}
	}

	// OTHER
	public static void replenishDeletePowerups() {
		availableDeletePowerups = maxDeletePowerups;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
