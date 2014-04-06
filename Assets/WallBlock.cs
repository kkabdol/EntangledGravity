using UnityEngine;
using System.Collections;

public class WallBlock : MonoBehaviour
{
	private WallManager wallManager;

	void Awake ()
	{
		wallManager = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<WallManager> ();
	}
	
	void OnTriggerEnter (Collider other)
	{
		Debug.Log ("WallBlock:OnTriggerEnter()");
		if (other.CompareTag (Tags.player) == true) {
			wallManager.Pause ();
		}
	}
}
