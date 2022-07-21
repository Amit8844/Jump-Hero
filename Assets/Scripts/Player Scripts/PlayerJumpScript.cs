﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerJumpScript : MonoBehaviour 
{

	public static PlayerJumpScript instance;

	private Rigidbody2D myBody;
	private Animator anim;

	[SerializeField]
	private float forceX, forceY;

	private float tersholdX = 7f;
	private float tresholdY = 14f;

	private bool setPower, didJump;

	private Slider powerBar;
	private float powerBarTreshold = 10f;
    private float powerBarValue = 0f;

	void Awake() 
	{
		MakeInstance ();
		Initiliaze ();
	}

	void Update() {
		SetPower ();
	}

	void Initiliaze() {
		powerBar = GameObject.Find ("Power Bar").GetComponent<Slider> ();
		myBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		powerBar.minValue = 0f;
		powerBar.maxValue = 10f;
		powerBar.value = powerBarValue;

	}

	void MakeInstance() {
		if (instance == null) 
			instance = this;
	}

	void SetPower() {

		if (setPower) {
			forceX += tersholdX * Time.deltaTime;
			forceY += tresholdY * Time.deltaTime;

			if(forceX > 6.5f)
				forceX = 6.5f;

			if(forceY > 13.5f)
				forceY = 13.5f;

			powerBarValue += powerBarTreshold * Time.deltaTime;
			powerBar.value = powerBarValue;

		}

	}

	public void SetPower(bool setPower) {
		this.setPower = setPower;

		if (!setPower) {
			Jump();
		}
	}

	void Jump() {
		myBody.velocity = new Vector2 (forceX, forceY);
		forceX = forceY = 0f;
		didJump = true;

		anim.SetBool ("Jump", didJump);

		powerBarValue = 0f;
		powerBar.value = powerBarValue;
	}

	void OnTriggerEnter2D(Collider2D target) {

		if (didJump) {
			didJump = false;

			anim.SetBool ("Jump", didJump);

			if (target.tag == "Platform") {
				if(GameManager.instance != null) {
					GameManager.instance.CreateNewPlatformAndLerp(target.transform.position.x);
				}

				if(ScoreManager.instance != null)
				{
					ScoreManager.instance.IncrementScore();
				}

			}
		}

		if (target.tag == "Dead")
		{
			if(GameOverManager.instance != null)
		    {
				GameOverManager.instance.GameOverShowPanel();
		    }
	     Destroy(gameObject);
		}
	}


} // PlayerJumpScript
































































