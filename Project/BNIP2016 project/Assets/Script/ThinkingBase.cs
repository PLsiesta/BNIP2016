using UnityEngine;
using System.Collections;

public class ThinkingBase : MonoBehaviour {

    
    public ThinkingBase[] m_NextModules;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public virtual ThinkingBase Thinking(GameObject Body)
    {


        return null;
    }
}
