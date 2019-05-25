using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
	[Range(250, 400)]
	public float speed = 5f;

	[Range(10, 30)]
	public float jumpSpeed = 5f;

	private Rigidbody2D _rb;
	private bool jump;

	void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

private void Update()
{
	if(Input.GetKeyDown(KeyCode.Space))
		jump = true;
}
	private void FixedUpdate()
	{
		if (jump)
		{
			Vector2 vel = _rb.velocity;
			vel.y = jumpSpeed;
			_rb.velocity = vel;
			jump = false;
		}

		float movement = Input.GetAxisRaw("Horizontal") * speed;

		if (movement < 0)
			GetComponent<SpriteRenderer>().flipX = true;

		if (movement > 0)
			GetComponent<SpriteRenderer>().flipX = false;

		Vector2 force = new Vector2(movement * Time.fixedDeltaTime, _rb.velocity.y);

		_rb.velocity = force;

		
		
		//TODO: Tirar o hard coded, colocar algo mais como "quando o player sair da tela" ou "atingir um collider la embaixo".
		if(transform.position.y < -6)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
