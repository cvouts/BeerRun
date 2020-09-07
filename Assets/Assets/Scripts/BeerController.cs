using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeerController : MonoBehaviour {

	public Slider beerSlider; 
  public Text text;

	private int beerLeft;

	void Awake()
	{
		beerLeft = 100;

    text.text = beerLeft + "% Beer left";
	}
  
  void OnCollisionEnter2D(Collision2D coll)
  {
    if (coll.gameObject.tag == "Arrow")
    {
      if(beerLeft > 0)
      {
        beerLeft -= 10;
        beerSlider.value = beerLeft;
        text.text = beerLeft + "% Beer left";
      }	
    }        
  }
}
