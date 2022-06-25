using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

    //Vector3 velocity = Vector3.zero;
    //public Vector3 gravity;
    float flapSpeed = 200f;
    float forwardSpeed = 1f;

    bool didFlap = false;
    bool dead = false;
    Animator animator;

	// Use this for initialization
	void Start () {
        animator = transform.GetComponentInChildren<Animator>();
        if(animator == null)
        {
            Debug.LogError("Cannot find animator for bird!");
        }
	}

    //do graphic and input update here
    void Update()
    {
        //we are calling the key down function in Update() instead of FixedUpdate() because when we press a key, it might not be called if this is in FxiedUpdate() in every frame
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            didFlap = true;
            
        }
    }
	
	
    // do physics engine updates here
	void FixedUpdate () {
        if (dead)
        {
            return;
        }

        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(Vector2.right * forwardSpeed);

        if (didFlap)
        {
            rigidbody2D.AddForce(Vector2.up * flapSpeed);
            animator.SetTrigger("DoFlap");
            didFlap = false;
        }

        float angle = 0;
        if(rigidbody2D.velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -80, -rigidbody2D.velocity.y / 6f);
            
        }
        else
        {
            angle = Mathf.Lerp(0, 30, rigidbody2D.velocity.y / 3f);
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);

        /*
        velocity.x = forwardSpeed;
        //since this function will be called 50 times per second, we want to update the position  and velocity each 1/50s by the position changed in 1/50s instead of very second
        //thus we update the position and velocity with velocity*Time.deltaTime instead of just velocity
        //if we update the position and velocity with just velocity each 1/50s, the position will be updated by that velocity and velocity will be updated by that gravity in each 1/50s
        //in a second(50 frames), the position will be updated a lot
        //velocity += gravity * Time.deltaTime;
        

        if (didFlap == true)
        {
            didFlap = false;
            velocity += flapVelocity; //change the velocity when pressing a key
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);// cap the max speed

        GetComponent<Rigidbody2D>().AddForce(velocity); 

        transform.position += velocity * Time.deltaTime;

        //changing the angle depends on the bird going up or down
        float angle = 0;
        if(velocity.y < 0)
        {
            angle = Mathf.Lerp(0, -80, -velocity.y/maxSpeed);
        }
        else
        {
            angle = Mathf.Lerp(0, 30, velocity.y/maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle); //rotation around z axes according to the angle
        */
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Death");
        dead = true;
    }
}
