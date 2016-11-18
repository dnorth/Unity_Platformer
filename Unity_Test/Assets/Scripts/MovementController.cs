using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float maxSpeed = 10.0f;
    bool facingRight = true;

    Animator anim;
    Rigidbody2D rigidBody;

	void Start ()
    {
        anim = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        float move = Input.GetAxis("Horizontal");
        anim.SetFloat("Movement", Mathf.Abs(move));

        rigidBody.AddForce(new Vector2(move * maxSpeed, rigidBody.velocity.y));

        if( move > 0 && !facingRight)
        {
            FlipFacing();
        }
        else if( move < 0 && facingRight)
        {
            FlipFacing();
        }
	}

    void FlipFacing()
    {
        facingRight = !facingRight;
        Vector3 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;
    }
}
