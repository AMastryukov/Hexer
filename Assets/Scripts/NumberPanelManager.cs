using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPanelManager : MonoBehaviour {

	private Transform[] panelNumbers;

	void Awake()
	{
		// get all numbers on the panel
		panelNumbers = new Transform[transform.childCount];

		for (int i = 0; i < transform.childCount; i++) {
			panelNumbers[i] = transform.GetChild (i);
		}
	}

	public Transform[] getPanelNumbers()
	{
		return panelNumbers;
	}

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			panelNumbers[i].gameObject.GetComponent<PanelNumber> ().panelIndex = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
