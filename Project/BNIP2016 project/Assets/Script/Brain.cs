using UnityEngine;
using System.Collections;

public class Brain : MonoBehaviour
{
    public ThinkingBase m_NowModule;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Think();
	}

    public void Think()
    {
        ThinkingBase tmpThinking = m_NowModule.Thinking(this.gameObject);

        if (tmpThinking)
            m_NowModule = tmpThinking; 
    }


}
