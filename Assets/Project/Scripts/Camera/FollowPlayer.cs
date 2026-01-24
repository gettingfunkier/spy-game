using UnityEngine;
using System.Collections;
using System.Reflection;


public class FollowCamera : MonoBehaviour {

	public Rigidbody2D body;
	public PlayerMovement movement;
	public Transform player;
	public Vector3 offset = new Vector3(0f, 1.5f, 0f);
	public float smooth;
	public float lookahead;

	private Vector3 velocity = Vector3.zero;

	float z;

	void Start ()
	{
		z = transform.position.z;
	}

	void FixedUpdate ()
	{
		Vector3 targetPos = player.position + (Vector3)offset;
		targetPos.z = z;
		targetPos.y = targetPos.y + .75f;

		if (movement.isSprintingRight)
		{
			targetPos.x += lookahead * movement.moveSpeed;
		}
		else if (movement.isSprintingLeft)
		{
			targetPos.x -= lookahead * movement.moveSpeed;
		}

		transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smooth);
	}
}