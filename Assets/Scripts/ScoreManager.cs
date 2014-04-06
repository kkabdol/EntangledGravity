using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	[HideInInspector]
	public int
		score = 0;

	private TextMesh scoreMesh;

	void Awake ()
	{
		scoreMesh = GameObject.FindGameObjectWithTag (Tags.scoreText).GetComponent<TextMesh> ();
		Add (0);
	}
	
	public void Add (int add)
	{
		score += add;
		scoreMesh.text = score.ToString ();
	}
}
