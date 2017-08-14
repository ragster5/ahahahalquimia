using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataqueMelee : MonoBehaviour {
	private IEnumerator coroutine;



	// Use this for initialization
	void Start () {

		coroutine = destruir ();
		StartCoroutine (coroutine);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	IEnumerator destruir(){

		yield return new WaitForSeconds(0.1f);

		Destroy(gameObject);



	}
}
