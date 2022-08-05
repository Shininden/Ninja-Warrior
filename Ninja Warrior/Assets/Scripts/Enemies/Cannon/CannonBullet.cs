using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBullet : MonoBehaviour
{
	[SerializeField] float spd;
	[SerializeField] int dmg;
	[SerializeField] float destroyTime;
	void Start()
	{
		Destroy(gameObject, destroyTime);
	}

	void Update()
	{
		transform.Translate(Vector3.right * spd * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerStatus otherPlayer = other.GetComponent<PlayerStatus>();

		if (otherPlayer != null)
		{
			otherPlayer.TookDamage(dmg);
			Destroy(gameObject);
		}
	}
}
