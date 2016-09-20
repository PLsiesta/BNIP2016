using UnityEngine;
using System.Collections;

public class BulletData : MonoBehaviour {

    float m_Speed;
    float m_DPS;
    UNIT_TYPE m_Type;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetData(Vector3 Speed, float DPS, UNIT_TYPE Type)
    {

        if (Type == UNIT_TYPE.FIGHTER)
            Speed = new Vector3(Speed.x, Speed.y, Mathf.Abs(Speed.z) * -1);
        else
            Speed = new Vector3(Speed.x, Speed.y, Mathf.Abs(Speed.z));
        
        m_DPS = DPS;
    }

    public float GetDPS()
    {

        return m_DPS;
    
    }
}
