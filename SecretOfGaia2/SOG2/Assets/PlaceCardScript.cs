using UnityEngine;
using System.Collections;
using SecretOfGaia;

public class PlaceCardScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        GameObject test = GameObject.Find("Gamezone/Hand").gameObject;
        GameObject gameZeone = GameObject.Find("Gamezone").gameObject;
        GameObject testDest = GameObject.Find("Gamezone/PlayedCard/Cardslot1").gameObject;
        GameObject test2 = test.transform.GetChild(0).gameObject;
        Debug.Log("aikjzdbnvijanepivnapiefnvpiajenfvijznefvnzpiefnvipzenfvijzne");
        GameZoneScript MonGameZone = gameZeone.GetComponent<GameZoneScript>();
        Debug.Log(MonGameZone.MyControler.joueurActif.cartesEnMain.ToList().Count);
        MonGameZone.MyControler.jouerUneCarteDepuisLaMain(MonGameZone.MyControler.joueurActif.cartesEnMain.ToList()[0]);
        //MonGameZone.DisplayHand();
        Debug.Log(MonGameZone.MyControler.joueurActif.cartesEnMain.ToList().Count);

        Vector3 newPos = new Vector3(0f, 0f, -1f);
        test2.transform.parent = testDest.transform;
        test2.transform.position = testDest.transform.position + newPos;
        Debug.Log(test2);
    }
}
