using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player_controller : MonoBehaviour
{
	public Text acceleration;
	public CharacterController2D controller;
	public Animator Ani; 
	public float runSpeed = 60f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	float accel;
	float time_f;
	int time;
	public bool play = true;
	private Rigidbody2D m_Rigidbody2D;
	bool is_ground;
	private void Start()
    {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		
		Ani = GetComponent<Animator>();

	    runSpeed += ((SceneManager.GetActiveScene().buildIndex-3)*1.4f);
		//Ani.speed += ((SceneManager.GetActiveScene().buildIndex - 3) * 0.0345f);

	}
    // Update is called once per frame
    void Update()
	{
		if(SceneManager.GetActiveScene().name == "FINAL") { }///the finale show
        else {
		//horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		accel = Input.acceleration.x;
		time_f += Time.deltaTime;
		time = Convert.ToInt32(time_f);
		horizontalMove = 1f * runSpeed;
		acceleration.text = "TIME : "+time.ToString();
#if UNITY_ANDROID
		if(accel > 0) { if (accel > 0.3f) { accel = 0.3f; } horizontalMove = runSpeed + (runSpeed * (accel-0.1f)); }
			else { if (accel < -0.3f) { accel = -0.3f; } horizontalMove = runSpeed + (runSpeed * (accel+0.1f)); }
#elif UNITY_IPHONE
        if(accel > 0) { horizontalMove = runSpeed + (runSpeed * (accel-0.1f)); }
            else { horizontalMove = runSpeed + (runSpeed * (accel+0.1f)); }	
#else
        if (accel < -0.2f || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			crouch = true;
			horizontalMove = 1f * runSpeed;
		}
		else if (accel > 0.2f || Input.GetKeyDown(KeyCode.RightArrow))
		{
			crouch = false;
			horizontalMove = runSpeed + (runSpeed*0.3f);
		}
		if ((accel< 0.2f && accel>-0.2)||((Input.GetKeyUp(KeyCode.LeftArrow))&& (Input.GetKeyUp(KeyCode.RightArrow))))
        {
			horizontalMove = 1f * runSpeed;
		}
#endif
			if ((Input.GetButtonDown("Jump") || Input.touchCount > 0))
		{
			jump = true;
			//m_Rigidbody2D.AddForce(new Vector2(0f, 1000));
			is_ground = false;
		}

		
		//Input.GetButtonDown("Crouch")
		}
	}

	void FixedUpdate()
	{
		if (play)
		{
			if (jump && !Ani.GetBool("jump")) { Ani.SetBool("jump", true); }

			controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
			jump = false;
		}
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.tag == "ground") { is_ground = true; }
		else { is_ground = false; }
	}
	void screen_oriantation()
    {
		if(Screen.orientation== ScreenOrientation.LandscapeLeft)
        {
			Time.timeScale = 1;
        }
        else
        {
			Time.timeScale = 0;
		}

	}
	public void jump_false()
    {
		Ani.SetBool("jump", false);
	}
}
