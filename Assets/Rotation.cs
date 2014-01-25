using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	private Quaternion quat_dest;
	private float orientation_z = 0.0f;
	// Use this for initialization
	void Start () {
		quat_dest = transform.rotation;
	}

	// Update is called once per frame
	void Update ()
	{
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, quat_dest, 0.04f);

		//this.transform.Rotate (Vector3.forward,(int) this.transform.rotation.z + (Time.deltaTime * 30.0f), Space.World);
		if (Input.GetKeyDown (KeyCode.Space)) {
			orientation_z += 90.0f;
			if (Mathf.Abs(orientation_z - 360.0f) < Mathf.Epsilon)
				orientation_z = 0.0f;
			quat_dest = Quaternion.AngleAxis(orientation_z, Vector3.forward);
		}
	}

}
