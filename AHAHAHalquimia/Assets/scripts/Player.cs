using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int speedX, forcaPulo;
	public float direcional, mouseLad, dano;
	public bool trocaDirec, atqMelee, atqPots, direMouse, pulo;
	private Rigidbody2D corpo;
	private SpriteRenderer pele;
	private Transform rotacao;
	public GameObject melee;
	public GameObject pots;
	private GameObject hp;
	//private Transform hpTrans;
	private barraVida sVida;
	private GameObject mana;
	private barraVapor sVapor;
	public int vida, vidaT;


	// Use this for initialization
	void Start () {
		
		corpo = GetComponent<Rigidbody2D> ();
		pele = GetComponent<SpriteRenderer> ();
		rotacao = GetComponent<Transform> ();
		hp = GameObject.Find ("vida");	
		//hpTrans = hp.GetComponents<Transform> ();
		sVida = hp.GetComponent <barraVida> ();
		mana = GameObject.Find ("vapor");
		sVapor = mana.GetComponent <barraVapor> ();

		vidaT = 200;//------------------------------------------pra mudar a vida total do personagem
		vida = vidaT;
	}
	
	// Update is called once per frame
	void Update () {
		direcional = Input.GetAxis ("Horizontal");

		atqMelee = Input.GetKeyDown (KeyCode.E);
		atqPots = Input.GetKeyDown (KeyCode.Q);




		//------------------------------------------------------------------------------movimento
		corpo.velocity = new Vector2 (direcional * speedX, corpo.velocity.y);


		//-------------------------------------------------------------------------------pulo
		if(Input.GetAxis("Jump") != 0 && pulo){
				
			corpo.velocity = new Vector2 (corpo.velocity.x, forcaPulo);
			pulo = false;							
			
		}
		//-------------------------------------------------------------------------------troca de lado
		if(direcional < 0){

			trocaDirec = true;//quando true quer dizer q ta pra esquerda
		} else if (direcional > 0){

			trocaDirec = false;
		}
		//--------------------------------------------------------------------------------------------------------------
		if  (Input.mousePosition.x<this.transform.position.x){//quando true quer dizer q ta pra esquerda do personagem 
			direMouse = true;
			mouseLad = -1.5f;
		}else if ( Input.mousePosition.x > this.transform.position.x){
			direMouse = false;
			mouseLad = 1.5f;
		}
		//-----------------------------------------------------------------------------chamada de metodos
		inveteLadoX();//---------------------------inveção da imagem

		if(atqMelee){//----------------------------chama de ataque
			ataqueMelee ();
		}
		if(atqPots){//------------------------------chama arremeço decimal pots
			ataqueDistancia ();
		}
		
	}

	void ataqueMelee(){//---------------------------------------------------------------comando de ataque basico
		if (sVapor.gastaMana (30)) {
			
			if (!trocaDirec) {
				
				Instantiate (melee, new Vector3 (this.transform.position.x + 1.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity, this.transform);

			} else if (trocaDirec) {
				
				Instantiate (melee, new Vector3 (this.transform.position.x - 1.5f, this.transform.position.y, this.transform.position.z), Quaternion.identity, this.transform);

			}
		}
	}
	void ataqueDistancia(){//-----------------------------------------------------------comando de aremeço de pots 


		//Instantiate (pots, new Vector3(this.transform.position.x+mouseLad, this.transform.position.y, this.transform.position.z),Quaternion.identity,this.transform);

			
		if(!trocaDirec){
				
			Instantiate (pots, new Vector3(this.transform.position.x+1.5f, this.transform.position.y, this.transform.position.z),Quaternion.identity,this.transform);
					
		} else if(trocaDirec){
				
			Instantiate (pots, new Vector3(this.transform.position.x-1.5f, this.transform.position.y, this.transform.position.z),Quaternion.identity,this.transform);
		}



	}
	void inveteLadoX(){//---------------------------------------------------------------inverte a imagem no eixo x
		if(trocaDirec){
				
			pele.flipX = true;
		}else if(!trocaDirec){
			pele.flipX = false;
		}
	}

	void OnCollisionEnter2D (Collision2D col)//--------------------------------------------colisão
	{
		switch (col.gameObject.tag) {
		case "terra":
			pulo = true;
			break;


		case "inimigo":
			
			int enDamege; 
			enDamege = 50;//------------------------------------------------------------dano do inimigo X

			//dano = (hpTrans.lossyScale[0]*enDamege)/vidaT;

			dano = (sVida.scaleXIni * enDamege)/vidaT;


			sVida.tirarVida (dano);
			print ("vida = "+vida);
			break;
		}

	}
}
