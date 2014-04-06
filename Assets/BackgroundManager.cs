using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundManager : MonoBehaviour
{
	public GameObject[] backgroundPrefabs;

	private const float distance = 30f;
	private GameObject player;
	private int genCount = 0;
	private List<GameObject> genedBackgrounds = new List<GameObject> ();

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag (Tags.player);
		genedBackgrounds.Add (GameObject.FindGameObjectWithTag (Tags.startingBackground));
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
			GameObject background = Instantiate (backgroundPrefabs [Random.Range (0, backgroundPrefabs.Length)]) as GameObject;
			background.transform.position = new Vector3 (genCount * distance, 0f, 0f);
			genedBackgrounds.Add (background);
		}
	}

	void UpdateDestructibleBackgrounds ()
	{
		List<GameObject> destructible = genedBackgrounds.FindAll (x => x.transform.position.x < player.transform.position.x - distance);

		for (int i=0, imax = destructible.Count; i<imax; ++i) {
			genedBackgrounds.Remove (destructible [i]);
			Destroy (destructible [i]);
		}
	}
}
