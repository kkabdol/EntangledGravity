using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RotateManager : MonoBehaviour
{
	public int count = 5;
	public float speed = 5f;
	public float rotateDelay = 1f;

	private ScoreManager scoreMng;
	private int lastRotateScore = 0;
	private float goalRotation = 0f;
	private List<float> rotation = new List<float>{0f, 90f, 180f, 270f};
	
	void Awake ()
	{
		scoreMng = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ScoreManager> ();
	}

	void Update ()
	{
		if (lastRotateScore + count <= scoreMng.score) {
			Invoke ("RotateCamera", rotateDelay);
			lastRotateScore = scoreMng.score;
		}

		Transform camTransform = Camera.main.transform;
		Quaternion from = camTransform.rotation;
		Quaternion to = Quaternion.Euler (0f, 0f, goalRotation);
		Camera.main.transform.rotation = Quaternion.Lerp (from, to, Time.deltaTime * speed);
	}

	void RotateCamera ()
	{
		List<float> copied = new List<float> (rotation);
		copied.Remove (goalRotation);

		goalRotation = copied [Random.Range (0, copied.Count)];
	}
}
