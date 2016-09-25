using UnityEngine;
using System.Collections;

public class CheckRate : ThinkingBase {

    public float[] m_NextModuleRate = new float[2];

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public override ThinkingBase Thinking(GameObject Body)
    {
        ThinkingBase tmp = this;
        float RandamRate = Random.Range(0.0f, 100.0f);
        float AllRate = 100.0f;

        for (int nNum = m_NextModules.GetLength(0) - 1; nNum >=  0; nNum--  )
        {
            if (RandamRate < AllRate && RandamRate > AllRate - m_NextModuleRate[nNum])
            {
                Debug.Log("SelectModule:" + nNum);
                tmp = m_NextModules[nNum].Thinking(Body);
                break;
            }
            AllRate -= m_NextModuleRate[nNum];
        }

        return tmp;
    } 
}
