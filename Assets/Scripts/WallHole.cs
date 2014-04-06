using UnityEngine;
using System.Collections;

public class WallHole : MonoBehaviour
{
	private ScoreManager score;

	void Awake ()
	{
		score = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ScoreManager> ();
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag (Tags.player) == true) {
			score.Add (1);
		}
	}
}
