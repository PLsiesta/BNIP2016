using UnityEngine;
using System.Collections;

public class Fighter : UnitBase {

    float m_Width;
    float m_Hight;
    public Vector3 m_MoveSize;
    bool m_Alive;
	// Use this for initialization
	void Start () {
        m_Width = Screen.width;
        m_Hight = Screen.height;
        m_Alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Alive)
        {
            if (transform.position.x < -7 || transform.position.x > 7)
                m_MoveSize.x *= -1;
            transform.Translate(m_MoveSize);
        }
        else
        {
            transform.parent.SendMessage("Death");
        }
	}

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.tag == "Bullet")
        {
            m_Alive = false;
        }
        
    }
}
