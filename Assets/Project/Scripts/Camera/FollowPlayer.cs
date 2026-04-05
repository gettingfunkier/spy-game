using UnityEngine;
using System.Collections;
using System.Reflection;


public class FollowCamera : MonoBehaviour {

	// scene instanced objects
	public PlayerMovement movement;
	public Transform player;


	// camera settings
	public Vector3 offset = new Vector3(0f, 1.5f, 0f);
	private Vector3 velocity = Vector3.zero;

	// variables
	public float smooth;
	public float horizontalLookahead;
	public float verticalLookahead;

	float z;

	void Start ()
	{
		z = transform.position.z;
	}

	void FixedUpdate ()
	{
		Vector3 targetPosition = player.position + (Vector3)offset;
		targetPosition.z = z;

		if (movement.isMovingRight)
		{
			targetPosition.x += horizontalLookahead * movement.moveSpeed;
		}
		else if (movement.isMovingLeft)
		{
			targetPosition.x -= horizontalLookahead * movement.moveSpeed;
		}

		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
	}

	void CheckLookaheadValues ()
	{
		// if player ever starts going out of bounds
	}
}