using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public float speed = 10f;

	private GameObject player;
	private Vector3 difference;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);

		difference = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.position = Vector3.Lerp (transform.position, player.transform.position - difference, Time.deltaTime * speed);
	}
}
