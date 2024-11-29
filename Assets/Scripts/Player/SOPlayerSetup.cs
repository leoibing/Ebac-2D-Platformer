using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
	[Header("Speed Setup")]
	public Vector2 friction = new Vector2(.1f, 0);
	public float speed = 10;
	public float speedRun = 21;
	public float forceJump = 20;

	[Header("Animation Setup")]
	public float jumpScaleY = 1.1f;
	public float jumpScaleX = .7f;
	public float animationDuration = .3f;

	public Ease ease = Ease.OutBack;

	[Header("Animation Player")]
	public string boolRun = "Run";
	public string boolJump = "Jump";
	public string triggerDeath = "Death";
	public float playerSwipeDuration = .1f;
}
