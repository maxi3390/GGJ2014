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
	/*	if (Input.GetKey (KeyCode.LeftArrow)) {
			moviendo = true;
			if (mueveDerecha) {
				this.transform.Rotate (0, 180, 0);
				mueveDerecha = false;
			}
			this.GetComponent<Animator> ().SetBool ("isSaltando", false);
			this.GetComponent<Animator> ().SetBool ("isCaminando", true);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			moviendo = true;
			if (!mueveDerecha) {
				this.transform.Rotate (Vector3.up,this.transform.rotation.y+180,Space.World);	
				mueveDerecha = true;
			}
			this.GetComponent<Animator> ().SetBool ("isSaltando", false);
			this.GetComponent<Animator> ().SetBool ("isCaminando", true);
		}
		if (!Input.GetKey (KeyCode.LeftArrow) || !Input.GetKey (KeyCode.RightArrow)) {
			if (Input.GetKey (KeyCode.Space)) {
					this.GetComponent<Animator> ().SetBool ("isCaminando", false);
					this.GetComponent<Animator> ().SetBool ("isSaltando", true);
			} else {
					this.GetComponent<Animator> ().SetBool ("isCaminando", false);
					this.GetComponent<Animator> ().SetBool ("isSaltando", false);
			}
		}
*/
	}

	public float maxSpeed = 5f;
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
		/*Vector2 v0 = new Vector2 (0f, 500f);
		float t = Time.deltaTime;
		v0.y = v0.y*t-0.5f*50f*(t*t);
		rigidbody2D.velocity = new Vector2 (0,(float) v0.y);*/
		if (Input.GetKeyDown (KeyCode.Space)) {
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

	void Flip()	{
		derecha = !derecha;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}

		
