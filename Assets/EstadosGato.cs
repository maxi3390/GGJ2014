using UnityEngine;
using System.Collections;

public class EstadosGato : MonoBehaviour {
	//private bool inContactWithWall;

	public enum TOUCH
	{
		NONE,
		FLOOR,
		CEIL,
		LEFT,
		RIGHT
	}

	//---*Flag de colision:
	public	TOUCH  isTouch = TOUCH.NONE;

	//private bool mueveDerecha = false;
	//private bool moviendo = false;
	// Use this for initialization
	void Start () {
		//inContactWithWall = true;
	}

	void OnCollisionEnter2D(Collision2D collision) {
		// print (collision.collider.name);
		 //Debug.Log("ENTER COLLISION");
		//inContactWithWall = true;

		foreach (ContactPoint2D contact in collision.contacts) 
		{		
			//Debug.Log(contact.normal.normalized);
			if (contact.normal.normalized == Vector2.up)
			{
				this.isTouch |= TOUCH.FLOOR; 
				//inContactWithWall = true;
			}
			if(contact.normal.normalized == (Vector2.up*-1))
			{
				//---*Si al menos ya 1 point toca el techo, se aniadie al bit:
				this.isTouch |= TOUCH.CEIL;
				//Debug.Log("toca techo");
			}
			if(contact.normal.normalized == (Vector2.right*-1))
			{
				//---*Si al menos ya 1 point toca del lado izquierdo, se aniadie al bit:
				this.isTouch |= TOUCH.RIGHT;
				
				//Debug.Log("toca izq");
			}
			if(contact.normal.normalized == (Vector2.right))
			{
				this.isTouch |= TOUCH.LEFT;
			}
		}
	}

	void OnCollisionExit2D(Collision2D collision) {
		//Debug.Log("EXIT COLLISION");
		//inContactWithWall = false;
	}

	void OnCollisionStay2D(Collision2D collision) 
	{
		//Debug.Log("STAY COLLISION");
		//inContactWithWall = true;
		//---*Recorremos todos los contactos:
		foreach (ContactPoint2D contact in collision.contacts) 
		{		
			//Debug.Log(contact.normal.normalized);
			if (contact.normal.normalized == Vector2.up)
			{
				this.isTouch |= TOUCH.FLOOR; 
				//inContactWithWall = true;
			}
			if(contact.normal.normalized == (Vector2.up*-1))
			{
				//---*Si al menos ya 1 point toca el techo, se aniadie al bit:
				this.isTouch |= TOUCH.CEIL;
				//Debug.Log("toca techo");
			}
			if(contact.normal.normalized == (Vector2.right*-1))
			{
				//---*Si al menos ya 1 point toca del lado izquierdo, se aniadie al bit:
				this.isTouch |= TOUCH.RIGHT;

				//Debug.Log("toca izq");
			}
			if(contact.normal.normalized == (Vector2.right))
			{
				this.isTouch |= TOUCH.LEFT;
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Debug.Log (this.isTouch);
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
		this.isTouch = TOUCH.NONE;
	}

	void saltar() {

		if(Input.GetKey(KeyCode.Space) && this.isTouching( TOUCH.FLOOR))
		rigidbody2D.AddForce (Vector2.up * 150f);
		
		this.GetComponent<Animator> ().SetBool ("isCaminando", false);
		this.GetComponent<Animator> ().SetBool ("isSaltando", true);
	}

	void sentar() {
		this.GetComponent<Animator> ().SetBool ("isCaminando", false);
		this.GetComponent<Animator> ().SetBool ("isSaltando", false);
		//print ("SE SIENTA");
	}

	
	//---*Ve si el flag de colision corresponde al ingresado
	public	bool isTouching(TOUCH flag)
	{
		return (this.isTouch & flag) != TOUCH.NONE;			
	}

	void caminar () {
		this.GetComponent<Animator> ().SetBool("isCaminando", true);

	}


	// flipa el gato
	void Flip()	{
		derecha = !derecha;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}