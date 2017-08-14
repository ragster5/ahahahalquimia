using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquePots : MonoBehaviour {
	private IEnumerator coroutine;
	private Rigidbody2D corpo;
	private Transform space;
	private GameObject carac;
	private SpriteRenderer pele;
	private float mouseY, focUp;
	public int speed, dire;

	// Use this for initialization
	void Start () {
		coroutine = destruir ();
		StartCoroutine (coroutine);

		corpo = GetComponent <Rigidbody2D> ();
		space = GetComponent <Transform> ();

		carac = GameObject.Find ("Personagem");
	

		Player sPlayer = carac.GetComponent<Player> ();

		/*
		if ( Input.mousePosition.x < this.transform.position.x ) {			
			dire = -1;
		} else if( Input.mousePosition.x > this.transform.position.x) {
			dire = 1;
		}
		*/
		if ( sPlayer.trocaDirec) {			
			dire = -1;
		} else if( !sPlayer.trocaDirec) {
			dire = 1;
		}

		focUp = Input.mousePosition.y/2 - this.transform.position.y;

		corpo.velocity = new Vector2 (speed*dire, focUp/40);

	}

	// Update is called once per frame
	void Update () {


		corpo.velocity = new Vector2 (speed*dire, corpo.velocity.y );


	}


	IEnumerator destruir(){

		yield return new WaitForSeconds(5f);

		Destroy(gameObject);



	}
}
