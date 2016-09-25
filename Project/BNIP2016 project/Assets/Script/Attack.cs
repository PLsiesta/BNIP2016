using UnityEngine;
using System.Collections;

public class Attack : ThinkingBase {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override ThinkingBase Thinking(GameObject Body)
    {
        Body.SendMessage("Fire");
        return m_NextModules[0];
    }
}
