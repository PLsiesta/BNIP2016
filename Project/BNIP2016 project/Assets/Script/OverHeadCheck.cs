using UnityEngine;
using System.Collections;

public class OverHeadCheck : ThinkingBase {

    bool m_Hit;
	// Use this for initialization
	void Start () {
        m_Hit = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override ThinkingBase Thinking(GameObject Body)
    {
        ThinkingBase tmp = null; 

        if (m_Hit)
            tmp = m_NextModules[0].Thinking(Body);

        return tmp;
    }

    void OnTriggerEnter(Collider Coll)
    {

        if (Coll.tag == "CheckPoint")
            m_Hit = true;
    
    }

    void OnTriggerExit(Collider Coll)
    { 
    
        if(Coll.tag == "CheckPoint")
            m_Hit = false;
    
    }
    
}
