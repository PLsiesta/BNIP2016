using UnityEngine;
using System.Collections;

public class Fighter : UnitBase {

    float m_Width;
    float m_Hight;
    bool m_Alive;
	// Use this for initialization
	void Start () {
        m_Width = Screen.width;
        m_Hight = Screen.height;
        m_Alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        int a = 10;
        m_PrevPosition = transform.position;

        if (m_Hp > 0)
        {
            transform.position += m_MoveSpeed * Time.deltaTime;
            if (transform.position.x <= -7 || transform.position.x >= 7)
            {
                transform.position = m_PrevPosition;
                m_MoveSpeed.x *= -1;
            }
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
            float DPS = Coll.GetComponent<BulletData>().GetDPS();
            m_Hp -= DPS;
            Destroy(Coll.gameObject);
        }
        
    }
}
