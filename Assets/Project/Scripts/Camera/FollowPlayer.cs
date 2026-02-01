using UnityEngine;
using System.Collections;
using System.Reflection;


public class FollowCamera : MonoBehaviour {

	// scene instanced objects
	public Rigidbody2D body;
	public PlayerMovement movement;
	public Transform player;


	// camera settings
	public Vector3 offset = new Vector3(0f, 1.5f, 0f);
	private Vector3 velocity = Vector3.zero;

	// variables
	public float smooth;
	public float lookahead;

	float z;

	void Start ()
	{
		z = transform.position.z;
	}

	void FixedUpdate ()
	{
		Vector3 targetPosition = player.position + (Vector3)offset;
		targetPosition.z = z;
		targetPosition.y = targetPosition.y + .75f;

		if (movement.isSprintingRight)
		{
			targetPosition.x += lookahead * movement.moveSpeed;
		}
		else if (movement.isSprintingLeft)
		{
			targetPosition.x -= lookahead * movement.moveSpeed;
		}

		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
	}
}