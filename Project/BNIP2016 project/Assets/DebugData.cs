using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugData : MonoBehaviour {

            GameObject[] m_DebugDatas;
            int          m_DebugDataNum;
    public  GameObject   m_Fighter;
            float        m_LastTime;
            float        m_FPS;
	// Use this for initialization
	void Start () {
        m_DebugDataNum = transform.childCount;
        m_LastTime = Time.time;
        m_DebugDatas = new GameObject[m_DebugDataNum];
        for (int nCnt = 0; nCnt < m_DebugDataNum; nCnt++)
            m_DebugDatas[nCnt] = transform.GetChild(nCnt).gameObject;
        
	}
	
	// Update is called once per frame
	void Update () {

        for (int nCnt = 0; nCnt < m_DebugDataNum; nCnt++)
        {
            switch (m_DebugDatas[nCnt].name)
            { 
                case "FPS":
                    if (Time.time - m_LastTime > 0.2)
                    {
                        m_DebugDatas[nCnt].GetComponent<Text>().text = "FPS:" + m_FPS * 5;
                        m_LastTime = Time.time;
                        m_FPS = 0;
                    }
                    break;
                case "HP":
                    if(m_Fighter != null)
                    m_DebugDatas[nCnt].GetComponent<Text>().text = "HP:" + m_Fighter.GetComponent<Fighter>().GetHp(); 
                    break;
            
            }
            
        
        }
        m_FPS++;
	
	}

}
