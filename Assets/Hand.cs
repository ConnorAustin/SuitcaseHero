using UnityEngine;
using System.Collections;

public class Hand : MonoBehaviour 
{
	public float movementSpeed;

	public float gripStrength;
	public float releaseStrength;

	Rigidbody2D palm;
	Rigidbody2D finger;
	Rigidbody2D thumb;

	Transform fingerTip;
	Transform thumbTip;

	void Start () 
	{
		finger = transform.FindChild("Palm/Finger").GetComponent<Rigidbody2D>();
		fingerTip = transform.FindChild("Palm/Finger/Tip");

		thumb = transform.FindChild("Palm/Thumb").GetComponent<Rigidbody2D>();
		thumbTip = transform.FindChild("Palm/Thumb/Tip");

		palm = GetComponent<Rigidbody2D>();
		Cursor.lockState = CursorLockMode.Locked;
	}

	void handleMovement()
	{
		float xOffset = Input.GetAxis("Mouse X") * movementSpeed * Time.deltaTime;
		float yOffset = Input.GetAxis("Mouse Y") * movementSpeed * Time.deltaTime;

		palm.AddForce(new Vector2(xOffset, yOffset));
	}
	
	void FixedUpdate () 
	{
		handleMovement();

		if(Input.GetMouseButton(0))
		{
			finger.AddForceAtPosition(Vector2.left * gripStrength * Time.deltaTime, new Vector2(fingerTip.position.x, fingerTip.position.y));

			thumb.AddForceAtPosition(Vector2.right * gripStrength * Time.deltaTime, new Vector2(thumbTip.position.x, thumbTip.position.y));
		}
		else
		{
			finger.AddForceAtPosition(Vector2.right * releaseStrength * Time.deltaTime, new Vector2(fingerTip.position.x, fingerTip.position.y));
			
			thumb.AddForceAtPosition(Vector2.left * releaseStrength * Time.deltaTime, new Vector2(thumbTip.position.x, thumbTip.position.y));
		}
	}
}
