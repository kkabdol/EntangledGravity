using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
	public GameObject[] backgrounds;

	private const float distance = 30f;
	private const float delta = distance / 2f;
	private GameObject player;
	private int genCount = 0;
	private List<GameObject> genedBackgrounds;
	private List<GameObject> backgroundPool;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);

		genedBackgrounds = new List<GameObject> ();
		backgroundPool = new List<GameObject> (backgrounds);
		for (int i=0, imax = backgroundPool.Count; i<imax; ++i) {
			backgroundPool [i].SetActive (false);
		}

		// ignore starting background
//		genedBackgrounds.Add (GameObject.FindGameObjectWithTag (Tags.startingBackground));
	}
	
	// Update is called once per frame
	void Update ()
	{
		UpdateGeneratingBackground ();
		UpdateDestructibleBackgrounds ();
	}

	void UpdateGeneratingBackground ()
	{
		if (player.transform.position.x > distance * genCount) {
			++genCount;
			GameObject background = backgroundPool [Random.Range (0, backgroundPool.Count)];
			background.SetActive (true);
			background.transform.position = new Vector3 (genCount * distance, 0f, 0f);
			genedBackgrounds.Add (background);
			backgroundPool.Remove (background);
		}
	}

	void UpdateDestructibleBackgrounds ()
	{
		List<GameObject> destructible = genedBackgrounds.FindAll (x => x.transform.position.x + distance < player.transform.position.x);

		for (int i=0, imax = destructible.Count; i<imax; ++i) {
			Debug.Log ("Background removed x:" + destructible [i].transform.position.x + " player x:" + player.transform.position.x);
			destructible [i].SetActive (false);
			backgroundPool.Add (destructible [i]);
			genedBackgrounds.Remove (destructible [i]);

		}
	}
}
