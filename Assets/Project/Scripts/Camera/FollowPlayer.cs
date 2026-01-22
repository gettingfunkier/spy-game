using UnityEngine;
using System.Collections;


public class FollowCamera : MonoBehaviour {

	public Transform player;
	public Vector3 offset = new Vector3(0f, 1.5f, 0f);
	public float smooth = 10f;

	float z;

	void Start ()
	{
		z = transform.position.z;
	}

	void FixedUpdate ()
	{
		Vector3 targetPos = player.position + (Vector3)offset;
		targetPos.z = z;

		transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime);
	}
}