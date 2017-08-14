using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barraVida : MonoBehaviour {
	private GameObject carac;
	private Transform space;
	private Player sPlayer;
	public float como, scaleXIni, scaleYIni, scaleZIni, rg;


	// Use this for initialization
	void Start () {
		space = GetComponent<Transform> ();

		carac = GameObject.Find ("Personagem");
		sPlayer = carac.GetComponent<Player> ();

		scaleXIni = space.lossyScale [0];
		scaleYIni = space.lossyScale [1];
		scaleZIni = space.lossyScale [2];

		rg = 0.2f;//----------------------------------------------------------  quantidade de reneração de vida
	}

	// Update is called once per frame
	void Update () {

		if (space.lossyScale[0] < 0) {//------------------------------------- impedir ir menos q zero
			space.localScale = new Vector3 (0.0000001f,scaleYIni,scaleZIni);
		}

		if(space.lossyScale[0] <scaleXIni){//-------------------------------  começa a regeneração caso a vida n esteja completa 
			regen ((scaleXIni * rg)/sPlayer.vidaT);
			//(sVida.scaleXIni * enDamege)/vidaT
		}
		if(space.lossyScale[0]>sPlayer.vidaT){//---------------------------------------   impede q a vida suba mais q o maximo 
			space.localScale = new Vector3 (scaleXIni,scaleYIni,scaleZIni);
		}
		
	}
	public void tirarVida(float dano){
		
		space.localScale -= new Vector3 ( dano ,0,0);
		//space.position -= new Vector3 (dano*6,0,0);

		
	}
	public void regen(float regen){
		space.localScale += new Vector3 ( regen ,0,0);
		//space.position += new Vector3 (regen*4,0,0);
	}

	public float getScale(int scl){
		return space.lossyScale [scl];
	}
	public float getScaleXIn(){
		return scaleXIni;
	}

}
