using UnityEngine;
using System.Collections;

public class Enemy : UnitBase {
    
    public GameObject m_EnemyPrefab;
    [SerializeField]
    bool    m_Head;
    bool    m_Rush;
    public GameObject m_HitEffect;
	// Use this for initialization
	void Start () {
        m_Head = false;
        m_Rush = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Head && m_ShotPossible)
            Fire();
        m_PrevPosition = transform.position;
        transform.Translate(m_MoveSpeed * Time.deltaTime);
        if (m_Hp <= 0)
            Destroy(this.gameObject);
	}

    void OnHead()
    {
        m_Head = true;
    }

    void Rush()
    {

        m_Rush = true;
        m_MoveSpeed = new Vector3(0, 0, 20);
    }

    void OnTriggerEnter(Collider Coll)
    {

        if (Coll.tag == "FighterBullet")
        {

            float DPS = Coll.GetComponent<BulletData>().GetDPS();
            Instantiate(m_HitEffect, transform.position, Quaternion.identity);
            m_Hp -= DPS;
            Destroy(Coll.gameObject);
        }
    
    }
    
}
