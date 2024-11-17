using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public Vector2 velocity;
	public float speed;

	private void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
		{
			//rb.MovePosition(rb.position - velocity * Time.deltaTime);
			rb.velocity = new Vector2(-speed, rb.velocity.y);
		}
		else if(Input.GetKey(KeyCode.RightArrow))
		{
			//rb.MovePosition(rb.position + velocity * Time.deltaTime);
			rb.velocity = new Vector2(speed, rb.velocity.y);
		}

	}
}
