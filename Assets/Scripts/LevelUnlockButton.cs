using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlockButton : MonoBehaviour {

	public int level;
	public AudioSource purchaseSound;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			purchaseSound.volume = Soundtrack.volume;

			if (StatisticsTracker.removeBits(StatisticsTracker.getLevelUnlockCost(level, LevelDifficulty.speed))) {
				purchaseSound.Play ();

				StatisticsTracker.levelUnlocks[level - 1, LevelDifficulty.speed - 1] = true;
				GameObject.Find ("LevelDifficulty").GetComponent<LevelDifficulty> ().UpdateLevelLocks ();
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
