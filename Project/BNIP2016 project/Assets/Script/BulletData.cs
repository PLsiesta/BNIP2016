using UnityEngine;
using System.Collections;

public class BulletData : MonoBehaviour {

    Vector3 m_Speed;
    float m_DPS;
    UNIT_TYPE m_Type;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > 14.0f || transform.position.z < -20.0f)
            Destroy(gameObject);
        Vector3 tmpSpeed = m_Speed * Time.deltaTime;
        transform.Translate(transform.TransformDirection(tmpSpeed.x, tmpSpeed.y, tmpSpeed.z));

	
	}

    public void SetData(Vector3 Speed, float DPS, UNIT_TYPE Type)
    {

        if (Type == UNIT_TYPE.FIGHTER)
            m_Speed = new Vector3(Speed.x, Speed.y, Mathf.Abs(Speed.z));
        else
            m_Speed = new Vector3(Speed.x, Speed.y, Mathf.Abs(Speed.z) * -1);
        
        m_DPS = DPS;
    }

    public float GetDPS()
    {

        return m_DPS;
    
    }
}
