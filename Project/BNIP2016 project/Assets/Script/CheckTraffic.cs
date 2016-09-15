using UnityEngine;
using System.Collections;

public class CheckTraffic : MonoBehaviour
{
    bool m_OnTraffic;
	// Use this for initialization
	void Start () {
        m_OnTraffic = false;
	}
	
	// Update is called once per frame
	void Update () {
        //m_OnTraffic = false; 
	}

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.tag == "Fighter")
            m_OnTraffic = true;
    }

    void OnTriggerExit(Collider Coll)
    {
        if (Coll.tag == "Fighter")
            m_OnTraffic = false;
                
    }

    public bool GetOnTraffic()
    {
        return m_OnTraffic;
    }

    public void ResetOnTraffic()
    {
        m_OnTraffic = false;
    }
}
