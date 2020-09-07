using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;

    Rigidbody2D rb2d;
    Vector2 initial;
    Vector2 movement;

    void Start ()
    {
    	rb2d = GetComponent<Rigidbody2D> ();

    	initial.Set(0.01f,0f);

   		movement = initial * speed;
    }

    void Update()
    {
    	rb2d.MovePosition(rb2d.position + movement);
    }

   void OnCollisionEnter2D(Collision2D col) 
   {
      if(col.collider.tag == "box")
      {
         Physics2D.IgnoreCollision(col.collider, this.GetComponent<Collider2D>());
      }
      else
      {
        Destroy(gameObject);
      }
		
   }

}