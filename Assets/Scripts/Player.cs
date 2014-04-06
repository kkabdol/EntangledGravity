using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public float jumpPower = 300.0f;
	public float jumpDelay = 0.5f;
	public float speed = 5f;
	public float restartDelay = 3f;

	private float lastJumpTime;
	private bool isAlive = true;
	private GameObject tutorialText;

	void Awake ()
	{
		isAlive = true;
		lastJumpTime = Time.time - jumpDelay;
		rigidbody.velocity = Vector3.right * speed;

		tutorialText = GameObject.FindGameObjectWithTag (Tags.tutorialText);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (isAlive) {
				Jump ();
			} else {
				ReloadLevel ();
			}
		} 
	}

	void Jump ()
	{
		if (lastJumpTime + jumpDelay <= Time.time) {
			rigidbody.velocity = new Vector3 (rigidbody.velocity.x, 0f, 0f);
			rigidbody.AddForce (Vector3.up * jumpPower);
			lastJumpTime = Time.time;
		}

		if (tutorialText.activeSelf) {
			tutorialText.SetActive (false);
		}
	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.CompareTag (Tags.wall) || collision.collider.CompareTag (Tags.ground)) {
			Die ();
		}
	}

	void Die ()
	{
		isAlive = false;
		rigidbody.velocity = Vector3.zero;

		tutorialText.SetActive (true);
		tutorialText.GetComponent<TextMesh> ().text = "Press SPACE to restart";
	}

	void ReloadLevel ()
	{
		Application.LoadLevel ("Game");
	}

}
