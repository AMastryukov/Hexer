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

	// per-level and overall stats
	public static int[] levelStats = new int[9] {0,0,0,0,0,0,0,0,0};
	public static int[] overallStats = new int[9] {0,0,0,0,0,0,0,0,0};

	// game progress
	public static bool[,] levelUnlocks = new bool[4,4];

	private static StatisticsTracker instance = null;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this);

			// load data from file or set the data to default
			if (!SaveLoadData.Load ()) {
				setDefaultValues ();
			}

		} else if (instance != this) {
			Destroy (this.gameObject);
			return;
		}
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

	public static int getLevelUnlockCost(int level, int speed) {
		int price = 32 * level * speed;

		for (int i = 0; i < level; i++) {
			for (int j = 0; j < speed; j++) {
				if (!levelUnlocks [i, j]) {
					price += 32 * (i+1) * (j+1);
				}
			}
		}

		return price;
	}

	// SETTERS
	public static void setAvailableBits(int bits) {
		availableBits = bits;
	}

	public static void setAssignmentPowerups(int powerups) {
		assignmentPowerups = powerups;
	}

	public static void setSwapPowerups(int powerups) {
		swapPowerups = powerups;
	}

	public static void setRandomizePowerups(int powerups) {
		randomizePowerups = powerups;
	}

	public static void setMaxDeletePowerups(int powerups) {
		maxDeletePowerups = powerups;
	}

	public static void setAvailableDeletePowerups(int powerups) {
		availableDeletePowerups = powerups;
	}

	public static void setOverallStats(int[] stats) {
		for (int i = 0; i < 9; i++) {
			overallStats[i] = stats [i];
		}
	}

	public static void setLevelUnlocks(bool[,] unlocks) {
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				levelUnlocks[i,j] = unlocks [i,j];
			}
		}
	}

	public static void setDefaultValues() {
		availableBits = 0;

		assignmentPowerups = 0;
		swapPowerups = 0;
		randomizePowerups = 0;
		maxDeletePowerups = 0;
		availableDeletePowerups = 0;

		// default unlocks
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 4; j++) {
				levelUnlocks [i,j] = false;
			}
		}

		levelUnlocks [0,0] = true;
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

	public static void updateOverallStats() {
		for (int i = 0; i < levelStats.Length; i++) {
			overallStats [i] += levelStats [i];
			levelStats [i] = 0;
		}

		// save the data to file
		SaveLoadData.Save();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
