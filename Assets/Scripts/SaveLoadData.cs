using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadData : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// saves the game data (statistics)
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Create (Application.persistentDataPath + "/playerData.dat");

		// copy statistics into the serializable data class
		PlayerData data = new PlayerData ();
		data.availableBits = StatisticsTracker.getAvailableBits ();
		data.assignmentPowerups = StatisticsTracker.getAssignmentPowerups ();
		data.swapPowerups = StatisticsTracker.getSwapPowerups ();
		data.randomizePowerups = StatisticsTracker.getRandomizePowerups ();
		data.maxDeletePowerups = StatisticsTracker.getMaxDeletePowerups ();
		data.overallStats = StatisticsTracker.overallStats;
		data.levelUnlocks = StatisticsTracker.levelUnlocks;

		// write to the file and close it
		bf.Serialize (file, data);
		file.Close ();
	}

	public static bool Load() {
		if (File.Exists (Application.persistentDataPath + "/playerData.dat")) {
			// read data from the file and deserialize it
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/playerData.dat", FileMode.Open);
			PlayerData data = (PlayerData)bf.Deserialize (file);
			file.Close ();

			// copy data from the PlayerData class into the game objects
			StatisticsTracker.setAvailableBits (data.availableBits);
			StatisticsTracker.setAssignmentPowerups (data.assignmentPowerups);
			StatisticsTracker.setSwapPowerups (data.swapPowerups);
			StatisticsTracker.setRandomizePowerups (data.randomizePowerups);
			StatisticsTracker.setMaxDeletePowerups (data.maxDeletePowerups);
			StatisticsTracker.setOverallStats (data.overallStats);
			StatisticsTracker.setLevelUnlocks (data.levelUnlocks);

			return true;
		} else {
			return false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	[Serializable]
	class PlayerData {
		public int availableBits;
		public int assignmentPowerups;
		public int swapPowerups;
		public int randomizePowerups;
		public int maxDeletePowerups;
		public int[] overallStats = new int[9];
		public bool[,] levelUnlocks = new bool[4,4];
	}
}
