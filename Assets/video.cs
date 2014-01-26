using UnityEngine;
using System.Collections;

public class video : MonoBehaviour {

	private MovieTexture text;
	// Use this for initialization
	void Start () {
		text = renderer.material.mainTexture as MovieTexture;
		text.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0) || Input.anyKeyDown) {
			text.Stop ();
			Application.LoadLevel ("menu");
		}
	}
}
