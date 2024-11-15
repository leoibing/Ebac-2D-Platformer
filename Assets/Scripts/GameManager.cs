using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Singleton;

public class GameManager : Singleton<GameManager>
{
	[Header("Player")]
	public GameObject playerPrefab;

	[Header("Enemies")]
	public List<GameObject> enemies;

	[Header("References")]
	public Transform startPoint;

	private GameObject _currentPlayer;

	private void Start()
	{
		Init();
	}

	public void Init()
	{
		SpawnPlayer();
	}

	public void SpawnPlayer()
	{
		_currentPlayer = Instantiate(playerPrefab);
		_currentPlayer.transform.position = startPoint.transform.position;
	}

}
