using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPurchase : MonoBehaviour {

	public int item;
	public int price;

	// Use this for initialization
	void Start () {
		
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			switch (item) {
			case 1:
				if (StatisticsTracker.removeBits(StatisticsTracker.getDeletePowerupCost())) {
					StatisticsTracker.addMaxDeletePowerup ();
				}
				break;
			case 2:
				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addAssignmentPowerup ();
				}
				break;
			case 3:
				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addSwapPowerup ();
				}
				break;
			case 4:
				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addRandomizePowerup ();
				}
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
