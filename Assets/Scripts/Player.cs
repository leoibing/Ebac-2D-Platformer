using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public Vector2 friction = new Vector2(.1f, 0);
	public float speed;
	public float speedRun;
	public float forceJump = 2;
	private float _currentSpeed;
	//private bool _isRunning;

	private void Update()
    {
		HandleJump();
		HandleMoviment();
	}

	private void HandleMoviment()
	{
		if(Input.GetKey(KeyCode.LeftControl))
			_currentSpeed = speedRun;
		else
			_currentSpeed = speed;

		//_isRunning = Input.GetKey(KeyCode.LeftControl);

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			//rb.MovePosition(rb.position + velocity * Time.deltaTime);
			rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
			//rb.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? speed : speedRun, rb.velocity.y);
		}

		if (rb.velocity.x > 0)
		{
			rb.velocity -= friction;
		}
		else if (rb.velocity.x < 0)
		{
			rb.velocity += friction;
		}
	}

	private void HandleJump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			rb.velocity = Vector2.up * forceJump;
	}
}
