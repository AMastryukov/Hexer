using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
	private GameObject[] spawners;

	void Awake()
	{
		//get all of the children (spawners)
		for (int i = 0; i < transform.childCount; i++) {
			spawners [i] = transform.GetChild (i).gameObject;
		}
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}
}
