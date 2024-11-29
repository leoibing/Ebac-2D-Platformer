using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	public Rigidbody2D rb;
	public HealthBase healthBase;

	[Header("Setup")]
	public SOPlayerSetup soPlayerSetup;

	/*[Header("Speed setup")]
	public Vector2 friction = new Vector2(.1f, 0);
	public float speed;
	public float speedRun;
	public float forceJump = 2;

	[Header("Animation setup")]
	public float jumpScaleY = 1.4f;
	public float jumpScaleX = .7f;
	public float animationDuration = .3f;
	public SOFloat soJumpScaleY;
	public SOFloat soJumpScaleX;
	public SOFloat soAnimationDuration;


	public Ease ease = Ease.OutBack;

	[Header("Animation player")]
	public string boolRun = "Run";
	public string boolJump = "Jump";
	public string triggerDeath = "Death";
	public float playerSwipeDuration = .1f;*/

	public Animator animator;

	private float _currentSpeed;
	//private bool _isRunning;

	private void Awake()
	{
		if (healthBase != null)
		{
			healthBase.OnKill += OnPlayerKill;
		}
	}

	private void OnPlayerKill()
	{
		healthBase.OnKill -= OnPlayerKill;
		animator.SetTrigger(soPlayerSetup.triggerDeath);
	}

	private void OnValidate()
	{
		if (rb == null)
			rb = GetComponent<Rigidbody2D>();

		if (animator == null)
			animator = GetComponent<Animator>();
	}

	private void Update()
	{
		HandleJump();
		HandleMoviment();
	}

	private void HandleMoviment()
	{
		if (Input.GetKey(KeyCode.LeftControl))
		{
			_currentSpeed = soPlayerSetup.speedRun;
			animator.speed = 2;
		}
		else
		{
			_currentSpeed = soPlayerSetup.speed;
			animator.speed = 1;
		}

		//_isRunning = Input.GetKey(KeyCode.LeftControl);

		if (Input.GetKey(KeyCode.LeftArrow))
		{
			rb.velocity = new Vector2(-_currentSpeed, rb.velocity.y);
			if (rb.transform.localScale.x != -1)
			{
				rb.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
			}
			animator.SetBool(soPlayerSetup.boolRun, true);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			//rb.MovePosition(rb.position + velocity * Time.deltaTime);
			rb.velocity = new Vector2(_currentSpeed, rb.velocity.y);
			if (rb.transform.localScale.x != 1)
			{
				rb.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
			}
			//rb.transform.localScale = new Vector2(1, 1);
			animator.SetBool(soPlayerSetup.boolRun, true);
			//rb.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? speed : speedRun, rb.velocity.y);
		}
		else
		{
			animator.SetBool(soPlayerSetup.boolRun, false);
		}

		if (rb.velocity.x > 0)
		{
			rb.velocity -= soPlayerSetup.friction;
		}
		else if (rb.velocity.x < 0)
		{
			rb.velocity += soPlayerSetup.friction;
		}
	}

	private void HandleJump()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			rb.velocity = Vector2.up * soPlayerSetup.forceJump;
			rb.transform.localScale = Vector2.one;
			animator.SetBool(soPlayerSetup.boolJump, true);

			DOTween.Kill(rb.transform);
			HandleScaleJump();
		}
		else
		{
			animator.SetBool(soPlayerSetup.boolJump, false);
		}
	}

	private void HandleScaleJump()
	{
		rb.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
		rb.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
	}

	public void DestroyMe()
	{
		Destroy(gameObject);
	}
}
