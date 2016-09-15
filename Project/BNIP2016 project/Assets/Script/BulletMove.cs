using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > 14.0f)
            Destroy(gameObject);

        transform.Translate( transform.TransformDirection(new Vector3(0.0f, 0.0f,-0.5f)));
	}
}
