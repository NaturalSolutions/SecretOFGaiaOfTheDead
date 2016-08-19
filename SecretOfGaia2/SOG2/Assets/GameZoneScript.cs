using UnityEngine;
using System.Collections;
using SecretOfGaia;
using UnityEngine.EventSystems;

public class GameZoneScript : MonoBehaviour {

    public GameObject test;
    public int nbInitCards;
    public RuleController MyControler;
    Camera camera;
    // Use this for initialization

    
    void Start () {

        camera = Camera.main;
        Joueur Joueur1 = GameStarter.obtenirJoueur1(); //player
        Joueur Ordi= GameStarter.obtenirJoueur2(); // IA
        MyControler = new RuleController();
        MyControler.demarerDuel(Joueur1, Ordi);
        this.DisplayHand();
        //GameObject PlayedCard = this.transform.GetChild(0).gameObject;
        //GameObject slot1 = PlayedCard.transform.GetChild(3).gameObject;
        //Vector3 positions = slot1.transform.position;
        
        //GameObject cardClone = (GameObject)Instantiate(test, positions,slot1.transform.rotation);
        //cardClone.transform.parent = PlayedCard.transform;
        ////Quaternion quat = new Quaternion(0, 0, 0, 0);
        //positions = positions + new Vector3(0f, 1f, 0f);

        ////positions.z = -1;

        ////positions.z = -1;
        //////cardClone.transform.position = slot1.transform.position;
        //cardClone.transform.rotation = slot1.transform.rotation;

        

        //Debug.Log(positions);
        //cardClone.transform.localScale = slot1.transform.localScale;
        //cardClone.transform.position = positions;
        //Debug.Log(cardClone.transform.position);
        
        //PlayedCard.gameObject.AddComponent();
        //Debug.Log(cardClone.transform.localScale);

       
    }


    public void DisplayHand()
    {

        GameObject Hand = this.transform.GetChild(1).gameObject;
        Renderer bezin;

        Bounds MaLimiteHand = ((Renderer)Hand.GetComponent<Renderer>()).bounds;

        //Vector3 Position = new Vector3(MaLimiteHand.min.x, -MaLimiteHand.min.y, Hand.transform.position.z) ;
        Vector3 Position = new Vector3(MaLimiteHand.min.x+20f, 0f, Hand.transform.position.z);
        //Vector3 Position = new Vector3(-0.35f, 0f, -1f);
        //Debug.Log(Position);

        //this.transform.DetachChildren();

        //Position = Position + new Vector3(0f, 0f, 0f);
            //Vector3 Position = camera.WorldToScreenPoint(Hand.transform.position);
        foreach (Carte curCarte in MyControler.joueurActif.cartesEnMain.GetAsList()){
            GameObject cardClone = (GameObject)Instantiate(test, new Vector3(0f, 0f, 0f), new Quaternion());
            
            Debug.Log(cardClone.transform.position);
            cardClone.transform.parent = Hand.transform;
            Debug.Log(cardClone.transform.position);
            //Debug.Log(cardClone.transform.position);
            cardClone.transform.localScale = test.transform.localScale;
            Bounds MaLimiteClone = ((Renderer)cardClone.GetComponent<Renderer>()).bounds;
            //Position = Position + new Vector3(MaLimiteClone.max.x - MaLimiteClone.min.x, 0, 0);
            Position = Position + new Vector3(((MaLimiteClone.max.x - MaLimiteClone.min.x)/2), 0f, -1f);
            Position.y = -(MaLimiteClone.max.y - MaLimiteClone.min.y);
            Debug.Log(cardClone.transform.position);
            Debug.Log("***************Position*********");
            Debug.Log(Position);
            Debug.Log(cardClone.transform.position);
            //Position.z = 0f;
            cardClone.transform.position = Position;
            Debug.Log(cardClone.transform.position);


            //Debug.Log(MaLimiteClone.min.x );
            //Debug.Log(MaLimiteClone.min.y);
            //Debug.Log((MaLimiteClone.min.x - MaLimiteClone.max.x)/100);
            //Position = Position + new Vector3(MaLimiteClone.max.x - MaLimiteClone.min.x, 1f, 0f);
            //Debug.Log(Position);
            

        }
    }
    void setHand(int nbCards)
    {
        GameObject PlayedCard = this.transform.GetChild(0).gameObject;
    }	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        Debug.Log("Schtroudel");
    }
}
