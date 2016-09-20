using UnityEngine;
using System.Collections;

public class Fightercontroller : MonoBehaviour {

    GameObject DeathEffect;
    GameObject MeshObj;
	// Use this for initialization
	void Start () {
        DeathEffect = transform.FindChild("Bon").gameObject;
        MeshObj     = transform.FindChild("model").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void Death()
    {

        DeathEffect.GetComponent<ParticleSystem>().Play();
        Destroy(MeshObj);
    
    }
}
