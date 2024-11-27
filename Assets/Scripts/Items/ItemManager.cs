using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
	public int coins;

	public TMP_Text coinText;

	private void Start()
	{
		Reset();
	}

	private void Reset()
	{
		coins = 0;
	}

	public void AddCoins(int amount = 1)
	{
		coins += amount;
		coinText.text = coins.ToString();
	}
}
