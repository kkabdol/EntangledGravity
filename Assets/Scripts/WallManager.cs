using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WallManager : MonoBehaviour
{
	public Transform[] genPos;
	public float genDelay = 1f;
	public GameObject wallPrefab;

	public float movingSpeed = 10f;
	
	private float lastGenTime;
	private List<GameObject> wallList = new List<GameObject> ();
	private bool isPaused = true;

	void Awake ()
	{
		lastGenTime = Time.time - genDelay;
		isPaused = true;
	}

	void Update ()
	{
		if (isPaused) {
			return;
		}

		if (lastGenTime + genDelay <= Time.time) {
			GenerateWall ();
			lastGenTime = Time.time;
		}
	}

	void FixedUpdate ()
	{
		if (isPaused) {
			return;
		}

		for (int i=0, imax = wallList.Count; i<imax; ++i) {
			if (wallList [i] != null) {
				Vector3 pos = wallList [i].transform.position;
				pos.x -= movingSpeed * Time.fixedDeltaTime;
				wallList [i].transform.position = pos;		
			} else {
				wallList.RemoveAt (i);
				--i;
			}
		}
	}

	void GenerateWall ()
	{
		Transform randomPos = genPos [Random.Range (0, genPos.Length)];
		GameObject wall = Instantiate (wallPrefab) as GameObject;
		wall.transform.position = randomPos.position;
		wallList.Add (wall);
	}

	public void Pause ()
	{
		Debug.Log ("WallManager paused");
		isPaused = true;
	}

	public void Resume ()
	{
		Debug.Log ("WallManager resumed");
		isPaused = false;
	}
}
