using UnityEngine;
using System.Collections;

public class testModule : ThinkingBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public override ThinkingBase Thinking(GameObject Body)
    {
        Debug.Log("Mudule0");
        return this;
    }

}
