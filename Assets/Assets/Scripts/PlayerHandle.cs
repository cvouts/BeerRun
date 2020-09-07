using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PlayerHandle : MonoBehaviour {

    public float speed;    
    public Animator anim;   

    Vector2 movement;
    Vector3 destination;
    float Xdifference;
    float Ydifference;


    void Start()
    {
        destination = new Vector3(0,0,0);
        Xdifference = Mathf.Abs(transform.position.x - destination.x);
        Ydifference = Mathf.Abs(transform.position.y - destination.y);
    }

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {   
            Vector3 touchPosition = Input.GetTouch(0).position;
            SetTouchDestination(touchPosition);
        }

        MoveWithTouch();
    }

    void SetTouchDestination(Vector3 touchPosition)
    {
        Camera  c = Camera.main;
        touchPosition.x = Input.GetTouch(0).position.x;
        touchPosition.y = /*c.pixelHeight -  */ Input.GetTouch(0).position.y;
        
        destination = c.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, c.nearClipPlane));

        if(destination.x < transform.position.x && transform.eulerAngles.y == 0)
        {
            Rotate(180);
        }
        if(destination.x > transform.position.x && transform.eulerAngles.y == 180)
        {
            Rotate(0);
        }
    }

    void MoveWithTouch()
    {
        transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime);
        Xdifference = Mathf.Abs(transform.position.x - destination.x);
        Ydifference = Mathf.Abs(transform.position.y - destination.y);

       if(transform.position != destination)
        {
            Animate();
            if(Xdifference < 0.1f && Ydifference < 0.1f)
            {
                transform.position = destination;
                anim.SetBool("Moving", false);
            }   
        }
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