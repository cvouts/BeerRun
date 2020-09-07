using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardTrigger : MonoBehaviour {

	public GameObject HazardSpawn;

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.tag == "Player")
		{
		 	HazardSpawn.SetActive(true);
		 }	
    }
}
