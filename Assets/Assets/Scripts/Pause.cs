using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

	public GameObject player;
	public GameObject HazardSpawn;
	public GameObject arrow;

	private bool paused;
	private PlayerHandle playerHandle;
	private Animator playerAnim;
	//private ProjectileMovement arrowMovement;
	private GameObject[] arrows;

	
	int i;

	void Start () {
		paused = false;
		playerHandle = player.GetComponent <PlayerHandle>();
        playerAnim = player.GetComponent <Animator>();
        
        arrows = GameObject.FindGameObjectsWithTag("Arrow");
        //arrowMovement = arrows.GetComponent <ProjectileMovement>();
	}
	

	void OnMouseDown()
	{
		if(paused == false)
		{
			Debug.Log("Paused");

			playerHandle.enabled = false;
			playerAnim.enabled = false;
			
			for(i=0; i < arrows.Length; i++)
			{
				arrows[i].GetComponent <Rigidbody2D>().bodyType = RigidbodyType2D.Static;
				arrows[i].GetComponent <ProjectileMovement>().enabled = false;;
			}

			HazardSpawn.SetActive(false);

			paused = true;
		}
		else if(paused == true)
		{	
			Debug.Log("Unpaused");

			playerHandle.enabled = true;
			playerAnim.enabled = true;

			for(i=0; i < arrows.Length; i++)
			{
				arrows[i].GetComponent <Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
				arrows[i].GetComponent <ProjectileMovement>().enabled = true;
			}
	
			HazardSpawn.SetActive(true);

			paused = false;
		}

	}

}
