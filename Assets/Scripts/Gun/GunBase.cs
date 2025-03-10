using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
	public ProjectileBase prefabProjectile;

	public Transform positionShot;
	public float timeBetweenShoot = .3f;
	private Coroutine _currentCoroutine;
	public Transform playerSideReference;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			_currentCoroutine = StartCoroutine(StartShoot());

		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
			if (_currentCoroutine != null)
				StopCoroutine(_currentCoroutine);
		}
	}

	IEnumerator StartShoot()
	{
		while (true)
		{
			Shoot();
			yield return new WaitForSeconds(timeBetweenShoot);
		}
	}

	public void Shoot()
	{
		var projectile = Instantiate(prefabProjectile);
		projectile.transform.position = positionShot.position;
		projectile.side = playerSideReference.transform.localScale.x;
	}
}
