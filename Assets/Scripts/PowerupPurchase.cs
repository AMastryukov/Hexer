using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupPurchase : MonoBehaviour {

	public int item;
	public int price;

	public AudioSource purchaseSound;

	// Use this for initialization
	void Start () {
		purchaseSound.volume = Soundtrack.volume;
	}

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0)) {
			switch (item) {
			case 1:
				price = StatisticsTracker.getDeletePowerupCost();

				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addMaxDeletePowerup ();
					purchaseSound.Play ();
				}
				break;
			case 2:
				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addAssignmentPowerup ();
					purchaseSound.Play ();
				}
				break;
			case 3:
				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addSwapPowerup ();
					purchaseSound.Play ();
				}
				break;
			case 4:
				if (StatisticsTracker.removeBits(price)) {
					StatisticsTracker.addRandomizePowerup ();
					purchaseSound.Play ();
				}
				break;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
