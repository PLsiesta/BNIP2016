using UnityEngine;
using System.Collections;

public class Fighter : UnitBase {

    float m_Width;
    float m_Hight;
    bool m_Alive;
    [SerializeField]
    float m_EmergencyLevel;
    public GameObject m_HitEffect;

	// Use this for initialization
	void Start () {
        m_Width = Screen.width;
        m_Hight = Screen.height;
        m_Alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        m_PrevPosition = transform.position;

        if (m_Hp > 0)
        {
            transform.position += m_MoveSpeed * Time.deltaTime;
            if (transform.position.x <= -7 || transform.position.x >= 7)
            {
                transform.position = m_PrevPosition;
                ReverseSpeed();
            }
        }
        else
        {
            transform.parent.SendMessage("Death");
        }

	}

    void OnTriggerEnter(Collider Coll)
    {
        if (Coll.tag == "GalagaBullet")
        {
            float DPS = Coll.GetComponent<BulletData>().GetDPS();
            GameObject tmp = (GameObject)Instantiate(m_HitEffect, transform.position, Quaternion.identity);
            tmp.transform.parent = transform;
            m_Hp -= DPS;
            if (m_Hp < 0)
                m_Hp = 0;
            Destroy(Coll.gameObject);
        }

        if (LayerMask.LayerToName(Coll.gameObject.layer) == "Galaga")
        {
            float DPS = 20;
            GameObject tmp = (GameObject)Instantiate(m_HitEffect, transform.position, Quaternion.identity);
            tmp.transform.localScale = new Vector3(20, 20, 20);
            tmp.transform.parent = transform;
            m_Hp -= DPS;
            if (m_Hp < 0)
                m_Hp = 0;

            Destroy(Coll.gameObject);
        }

    }

    void SetEmergencyLevel(string Tag, string Layer)
    {
        switch(Layer)
        {
            case "Galaga":
                m_EmergencyLevel = 0.0f;
                break;
            case "Default":
                switch (Tag)
                { 
                    case "Bullet":
                        m_EmergencyLevel = 2.0f;
                        break;
                    case "Untagged":
                        break;
                
                }
            break;
        }
    }

    void RunThinking()
    {
        //m_Thinkings[(int)m_EmergencyLevel].gameObject.SendMessage("");
    }

    public void ReverseSpeed()
    {

        m_MoveSpeed.x *= -1;

    
    }
}
