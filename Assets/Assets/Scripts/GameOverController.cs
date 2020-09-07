using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour {

	public Slider beerSlider; 
	public Text gameOverText;
	public float restartDelay = 5f;
	public GameObject player;
	public GameObject HazardSpawn;
	public bool gameoverTrigger;

	private PlayerHandle playerHandle;
	private Animator anim;
	private Animator gameoverAnim;
	private float restartTimer;
	private bool successfulLevel;
	private Text endText;

	void Start () 
	{	
		gameoverTrigger = false;
		successfulLevel = false;

		gameoverAnim = gameOverText.GetComponent <Animator>();

		endText = gameOverText.GetComponent <Text>();

        playerHandle = player.GetComponent <PlayerHandle>();
        anim = player.GetComponent <Animator>();
	}
	
	void Update () {
		
		if (beerSlider.value == 0 && gameoverTrigger == false)
		{
			GameOver();
		}

		if(gameoverTrigger==true)
		{
			Restart();
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.tag == "Player" && HazardSpawn.activeInHierarchy == true) //HazardSpawn.active == true)
		{
			successfulLevel = true;
		 	GameOver();
		 }	
    }

	void GameOver()
	{
		gameoverTrigger = true;

		if(successfulLevel == true)
		{
			endText.text = "Success!";
		}
		gameoverAnim.SetTrigger("GameOver");
	
		playerHandle.enabled = false;
		anim.SetBool("Moving", false);
	
		HazardSpawn.SetActive(false);

	}

	void Restart()
	{
		 restartTimer += Time.deltaTime;

        if(restartTimer >= restartDelay)
        {
        	if(successfulLevel == false)
        	{
        		SceneManager.LoadScene("Level01", LoadSceneMode.Single);	
        	}
        	else
        	{
        		SceneManager.LoadScene("Level02", LoadSceneMode.Single);
        	}
            
        }
	}
}
