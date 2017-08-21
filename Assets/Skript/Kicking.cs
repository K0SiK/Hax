using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Kicking : NetworkBehaviour
{
    public float power = 20f;

    private CircleCollider2D colider;
    private CircleCollider2D ballColider;
    private Rigidbody2D ballBody;
  
 
    int counter = 0;

    void Start()
    {
        colider = gameObject.GetComponent<CircleCollider2D>();
        
        GameObject ball = GameObject.FindGameObjectsWithTag("Ball")[0];
        ballColider = ball.GetComponent<CircleCollider2D>();
        ballBody = ball.GetComponent<Rigidbody2D>();
        
        
    }

    void FixedUpdate()
    {
        kick();
   
    }

    [Command]
    void  kick()
    {
        if (Input.GetKeyDown("space")

       && colider.IsTouching(ballColider))
        {

            print("space key was pressed");


            Vector2 v = ballBody.gameObject.transform.position - transform.position;
            v = v / v.magnitude;
            v = v * power * 100;
            ballBody.AddForce(v);
        }


        if (colider.IsTouching(ballColider))
        {
            counter++;
            print(counter);
        }
    }
}