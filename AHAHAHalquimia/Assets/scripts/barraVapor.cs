using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraVapor : MonoBehaviour {
	private GameObject carac;
	private Transform space;
	private Player sPlayer;
	public float como, scaleXIni, scaleYIni, scaleZIni, rgVapor;
	public int vaporT;

	// Use this for initialization --------------------------------------------------------comentario de testo do git

	void Start () {
		space = GetComponent<Transform> ();

		carac = GameObject.Find ("Personagem");
		sPlayer = carac.GetComponent<Player> ();

		scaleXIni = space.lossyScale [0];
		scaleYIni = space.lossyScale [1];
		scaleZIni = space.lossyScale [2];

		rgVapor = 0.003f; //-------------------------------------------------- regeneração de vapor
		vaporT = 200;
	}
	
	// Update is called once per frame
	void Update () {
		if (space.lossyScale[0] < 0) {//------------------------------------- impedir ir menos q zero
			space.localScale = new Vector3 (0,scaleYIni,scaleZIni);
		}

		if(space.lossyScale[0] <scaleXIni){
			regenVapor (rgVapor);
			//(sVida.scaleXIni * enDamege)/vidaT
		}
		if(space.lossyScale[0]>scaleXIni){
			space.localScale = new Vector3 (scaleXIni,scaleYIni,scaleZIni);
		}

	}

	public void gastVapor(float gasto){
		space.localScale -= new Vector3 ( gasto ,0,0);
	}

	public void regenVapor(float rgVapor){
		space.localScale += new Vector3 ( rgVapor ,0,0);

	}

	public bool gastaMana(int gasto){
		float gstF = (scaleXIni * gasto) / vaporT;

		if (gstF < space.lossyScale [0]) {
			space.localScale -= new Vector3 (gstF, 0, 0);
			return true;
		} else {
			return false;
		}

	}
}
