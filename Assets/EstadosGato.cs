using UnityEngine;
using System.Collections;

public class EstadosGato : MonoBehaviour {
	private bool inContactWithWall;
	//private bool mueveDerecha = false;
	//private bool moviendo = false;
	// Use this for initialization
	void Start () {
		inContactWithWall = true;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		// print (collision.collider.name);
		// Debug.Log("ENTER COLLISION");
		inContactWithWall = true;
	}

	void OnCollisionExit2D(Collision2D collision) {
		//Debug.Log("EXIT COLLISION");
		inContactWithWall = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	public float maxSpeed;
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
				// camina y se fija si salta
				caminar();
				saltar();
			}

			// Si el gato no se mueve puede estar quieto o saltando:
			if (!Input.GetKey (KeyCode.LeftArrow) && !Input.GetKey (KeyCode.RightArrow)) {
				if (Input.GetKey (KeyCode.Space)) {
					saltar();
				} else {
					sentar();
					this.gameObject.GetComponent<AudioSource> ().Play ();
				}
			}
		}
	}

	void saltar() {
		if (Input.GetKeyDown (KeyCode.Space) && inContactWithWall) {
			rigidbody2D.AddForce (Vector2.up * 300f);
		}
		this.GetComponent<Animator> ().SetBool ("isCaminando", false);
		this.GetComponent<Animator> ().SetBool ("isSaltando", true);
	}

	void sentar() {



		this.GetComponent<Animator> ().SetBool ("isCaminando", false);
		this.GetComponent<Animator> ().SetBool ("isSaltando", false);
		//print ("SE SIENTA");
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