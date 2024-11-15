using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MenuButtonsManager : MonoBehaviour
{
	public List<GameObject> buttons;

	public float duration = 0.2f;
	public float delay = 0.5f;
	public Ease ease = Ease.OutBack;

	private void Awake()
	{
		HideAllButtons();
		ShowButtons();
	}

	private void HideAllButtons()
	{
		foreach (var b in buttons)
		{
			b.transform.localScale = Vector3.zero;
			b.SetActive(false);
		}
	}

	private void ShowButtons()
	{
		for (int i = 0; i < buttons.Count; i++)
		{
			var b = buttons[i];
			b.SetActive(true);
			b.transform.DOScale(1, duration).SetDelay(1*delay).SetEase(ease);
		}

	}
}
