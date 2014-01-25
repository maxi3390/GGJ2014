using UnityEngine;
using System.Collections;

public class FollowCharacter : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x, target.position.y, this.transform.position.z);
	}
}
