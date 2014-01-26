using UnityEngine;
using System.Collections;

public class EstadosGato : MonoBehaviour {

	//private bool mueveDerecha = false;
	//private bool moviendo = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public float maxSpeed = 1f;
	public bool derecha = false;
	void FixedUpdate () {
		sentar();

		float move = Input.GetAxis ("Horizontal");
		rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
		if (move > 0 && !derecha) {
			Flip ();
		} else {
			if (move < 0 && derecha){
				Flip();
			}
			if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.RightArrow)) {
				caminar();
				// como tambien puede saltar, preguntamos si esta saltando
				saltar();
			}

			// Si el gato no se mueve puede estar quieto o saltando:
			if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
				if (Input.GetKey (KeyCode.Space)) {
					saltar();
				} else {
					sentar();
				}
			}
		}
	}

	void saltar() {
		if (Input.GetKeyDown (KeyCode.Space) && !this.GetComponent<Animator>().GetBool("isSaltando")) {
			rigidbody2D.AddForce (Vector2.up * 300f);
		}
		this.GetComponent<Animator> ().SetBool ("isCaminando", false);
		this.GetComponent<Animator> ().SetBool ("isSaltando", true);
	}

	void sentar() {
		this.GetComponent<Animator> ().SetBool ("isCaminando", false);
		this.GetComponent<Animator> ().SetBool ("isSaltando", false);
	}

	void caminar () {
		this.GetComponent<Animator> ().SetBool ("isCaminando", true);
	}


	// flipa el gato
	void Flip()	{
		derecha = !derecha;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}

		
