using UnityEngine;
using System.Collections;

public class CheckAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.tag == "Bullet" || Coll.tag == "Galaga")
        {
            //transform.parent.SendMessage("OnEmergency");
        }
        
    
    }

}
