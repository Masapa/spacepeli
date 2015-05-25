using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
	public float speed = 10f;
	Transform _transform;
	Vector3 mouse;
	Vector3 katso;
	public float aika = 0.5f;
	float aikatmp;
	bool ylos = false;
	bool alas = false;
	bool oikealle = false;
	bool vasemmalle = false;

	Transform vasen;
	Transform oikea;
	Rigidbody2D rb;
	bool kumpi = false;

	GameObject bullet;

	// Use this for initialization
	void Start () {
		aikatmp = 0;
		bullet = Resources.Load<GameObject> ("ammus");
		rb = GetComponent<Rigidbody2D> ();
		vasen = transform.Find ("vasen");
		oikea = transform.Find ("oikea");
		_transform = transform;
		kaannaHiireen ();

	
	}

	void ammu(){
		if (aikatmp > aika) {
			if (kumpi) {
				GameObject tmp = Instantiate (bullet, vasen.position, vasen.rotation) as GameObject;
				ammus tmp2 = tmp.GetComponent<ammus> ();
				tmp2.dmg = 10;
				tmp2.speed = 800;
				kumpi = false;
				tmp2.omistaja = gameObject.tag;
			} else {
				GameObject tmp = Instantiate (bullet, oikea.position, oikea.rotation) as GameObject;
				ammus tmp2 = tmp.GetComponent<ammus> ();
				tmp2.dmg = 10;
				tmp2.speed = 800;
				kumpi = true;
				tmp2.omistaja = gameObject.tag;

		
			}
			aikatmp = 0;
		}


	}

	void liiku(){
		if(Input.GetKey(KeyCode.W)){

			ylos = true;
		}else ylos = false;

		if(Input.GetKey(KeyCode.S)){
			
			alas = true;
		}else alas = false;

		if(Input.GetKey(KeyCode.D)){
			
			oikealle = true;
		}else oikealle = false;

		if(Input.GetKey(KeyCode.A)){
			
			vasemmalle = true;
		}else vasemmalle = false;


	
	}

	void kaannaHiireen(){
		mouse = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,10);
		katso = Camera.main.ScreenToWorldPoint (mouse);
		katso = katso - _transform.position;
		float angle = Mathf.Atan2 (katso.y, katso.x) * Mathf.Rad2Deg-90	;
		_transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);


	}
	
	// Update is called once per frame
	void Update () {
		kaannaHiireen ();
		liiku ();
		if (Input.GetMouseButton (0)) {
			ammu();
		
		}
		aikatmp += Time.deltaTime;
	}

	void FixedUpdate(){
		if (ylos)
			rb.AddForce (_transform.up * speed);
		if (alas)
			rb.AddForce (-_transform.up * speed);
		if (oikealle)
			rb.AddForce (_transform.right * speed);
		if (vasemmalle)
			rb.AddForce (-_transform.right * speed);


	}
}
