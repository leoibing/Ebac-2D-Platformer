using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
	public SOInt amount;

	protected override void OnCollect()
	{
		base.OnCollect();
		if (amount != null)
			ItemManager.instance.AddCoins(amount.value);
	}
}
