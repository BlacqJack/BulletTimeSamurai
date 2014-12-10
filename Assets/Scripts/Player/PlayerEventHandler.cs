﻿using UnityEngine;
using System.Collections;

public class PlayerEventHandler : MonoBehaviour
{
	Transform trans;
	Rigidbody2D rigid;
	public GameObject swingParticle;
	public bool alive = true;
	public float particleSpeed = 30f;

	// Use this for initialization
	void Start()
	{
		trans = this.GetComponent<Transform>();
		rigid = this.GetComponent<Rigidbody2D>();


	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(Time.deltaTime.ToString());
	}

	public void Attack_1()
	{


		CreateSwingParticle();
	}

	void CreateSwingParticle()
	{
		if (PlayerController.turnedRight)
		{
			var particle = Object.Instantiate(swingParticle, new Vector3(trans.localPosition.x + 0.4f, trans.localPosition.y + 0.15f, 0f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
			//particle.rigidbody2D.AddForce(Vector2.right * particleSpeed);
		}
		else
		{
			var particle = GameObject.Instantiate(swingParticle, new Vector3(trans.localPosition.x - 0.4f, trans.localPosition.y + 0.15f, 0f), new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
			particle.transform.localScale = new Vector3(-1f, 1f, 1f);

			//particle.rigidbody2D.AddForce(Vector2.right * particleSpeed * -1f);
		}
	}

	void KillPlayer()
	{
		Debug.Log("Player is kill :(");

		alive = false;
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.tag == "Bullet")
		{
			Destroy(coll.gameObject);
			KillPlayer();
		}
	}
}
