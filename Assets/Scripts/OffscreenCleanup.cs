using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanupScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Destroy (other.gameObject);
		Debug.Log ("OBJECT REMOVED");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
