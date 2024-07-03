using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFences : MonoBehaviour
{
	public GameObject pillars;
	private bool IsOn = false;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (IsOn == false)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				pillars.SetActive(true);
				IsOn = true;
			}
		}
	}
	void Start()
	{
     pillars.SetActive(false);
	}
}
