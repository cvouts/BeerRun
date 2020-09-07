using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class OldPlayerHandle : MonoBehaviour {

    public float speed;    
    public Animator anim;   

    Vector2 movement;
    Rigidbody2D rb2d;    


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        
    }

    void FixedUpdate()
    {
      
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        if(moveHorizontal != 0 || moveVertical != 0)
	    { 
	    	Animate();

	    	Move(moveHorizontal,moveVertical);
    	}
	    else
	    {
	    	anim.SetBool("Moving", false);
	    } 

    }

    void Move(float moveHorizontal, float moveVertical)
    {
        if(moveVertical != 0f)
        {
            movement.Set(0f, moveVertical);

            movement = movement * speed * Time.deltaTime;
        }
        else if(moveHorizontal != 0f)
        {
            movement.Set(moveHorizontal, 0f);

            movement = movement * speed * Time.deltaTime;

            if(moveHorizontal < 0 && transform.eulerAngles.y == 0)
            {
                Rotate(180);
            }
            else if(moveHorizontal > 0 && transform.eulerAngles.y == 180)
            {
                Rotate(0);
            }
        }
    
        rb2d.MovePosition(rb2d.position + movement);
    }

    void Animate()
    {
    	anim.SetBool("Moving", true);
    }

    void Rotate(int direction)
    {  	
    	transform.eulerAngles = new Vector3(0, direction, 0);
    }


}