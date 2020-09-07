using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level01Instructions : MonoBehaviour {

	public Image instructions;

	private bool instructionsTriggered;
	private bool gameoverTriggered;
	private Animator instructionsFadeAwayAnim;
	
	void Start () 
	{
		instructionsTriggered = false;
		instructionsFadeAwayAnim = instructions.GetComponent <Animator> ();
		gameoverTriggered = false;
	}
	
	void Update () 
	{
		gameoverTriggered = this.GetComponent <GameOverController>().gameoverTrigger;
		if(gameoverTriggered == true && instructionsTriggered == false)
		{
			instructionsFadeAwayAnim.SetTrigger("GameOver");
			instructionsTriggered = true;
		}
	}
}
