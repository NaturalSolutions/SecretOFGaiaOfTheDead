using UnityEngine;
using System.Collections;

public class CardScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<Collider>().enabled = true;

    }

    public bool prout = true;

    public void OnClick()
    {
        Debug.Log("Schtroudel");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log("Name = " + hit.collider.name);
                //Debug.Log("Tag = " + hit.collider.tag);
                //Debug.Log("Hit Point = " + hit.point);
                //Debug.Log("Object position = " + hit.collider.gameObject);
                //Debug.Log("--------------");
            }
        }
    }
    void OnMouseDown()
    {
        Debug.Log("Schtroudel");
        float turnSpeed = 50f;
        float moveSpeed = -100f;
        float moveSpeedRight = 100f;
        //this.transform.rotation = Quaternion.Slerp(new Quaternion(0, 10f, 0, 0), new Quaternion(0,40f,0,0), Time.time * 0.01f);
        if (prout)
        {
            this.transform.Translate(Vector3.forward * moveSpeed);
            this.transform.Translate(Vector3.right * moveSpeedRight);
            
        }else
        {
            this.transform.Translate(Vector3.forward * -moveSpeed);
            this.transform.Translate(Vector3.right * -moveSpeedRight);
        }
        prout = !prout;
        Debug.Log("qijzhsdfvpiu");
        
    }

    IEnumerable test()
    {
        yield return new WaitForSeconds(1);
    }



}
