using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	private Quaternion quat_dest;
	private float orientation_z = 0.0f;
	public Transform character;
	public float velocity;

	private float myTime;
	private int rotationTime;
	private bool girando;

	// Use this for initialization
	void Start () {
		quat_dest = transform.rotation;

		myTime = 0f;
		girando = false;
		rotationTime = 4;
	}

	// Update is called once per frame
	void Update ()
	{
		//velocity = (Random.Range(1,10))/100.0f;
		velocity = (Random.Range(1,3))/10.0f;
		// generamos un numero aleatorio entre 0 y 9. Hacemos -1 elevado a ese random
		int sentidoDeGiro = Random.Range (0, 9);
		this.transform.rotation = Quaternion.Slerp (this.transform.rotation, quat_dest, velocity);
		this.character.rotation = Quaternion.Slerp (this.character.rotation,
		                                            new Quaternion(this.character.rotation.x,this.character.rotation.y,this.character.rotation.z,-this.character.rotation.w), velocity);
		


		//this.transform.Rotate (Vector3.forward,(int) this.transform.rotation.z + (Time.deltaTime * 30.0f), Space.World);
		//if (Input.GetKeyDown (KeyCode.R))
		myTime += Time.deltaTime;
		if ((myTime - rotationTime) > 0 && !girando) {
				this.gameObject.GetComponent<AudioSource>().Play ();
				orientation_z += 90.0f * Mathf.Pow (-1, sentidoDeGiro);
				if (Mathf.Abs (orientation_z - 360.0f) < Mathf.Epsilon)
						orientation_z = 0.0f;
				quat_dest = Quaternion.AngleAxis (orientation_z, Vector3.forward);
				girando = true;
			myTime = 0f;
				
		} else
				girando = false;
	}

}
