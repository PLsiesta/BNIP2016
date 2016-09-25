using UnityEngine;
using System.Collections;

public class WaitTime : ThinkingBase {

    float           m_LastTime;
    public float    m_WaitTime;
    bool            m_NowCall;
	// Use this for initialization
	void Start () {
        m_LastTime = Time.time;
        m_NowCall = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override ThinkingBase Thinking(GameObject Body)
    {
        if (!m_NowCall)
        {
            m_LastTime = Time.time;
            m_NowCall = true;
        }

        if ((Time.time - m_LastTime) > m_WaitTime)
        {

            m_NowCall = false;
            return m_NextModules[0];
        }
        return this;
    }
}
