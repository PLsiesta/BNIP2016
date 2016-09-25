using UnityEngine;
using System.Collections;

public class Avoidance : ThinkingBase {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override ThinkingBase Thinking(GameObject Body)
    {

        ThinkingBase tmp = this;
        Body.SendMessage("ReverseSpeed");
        tmp = m_NextModules[0].Thinking(Body);
        return tmp;
    }
}
