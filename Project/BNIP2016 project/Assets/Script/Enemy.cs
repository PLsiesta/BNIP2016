using UnityEngine;
using System.Collections;

public class Enemy : UnitBase {
    
    public GameObject m_EnemyPrefab;
    [SerializeField]
    bool    m_Head;

	// Use this for initialization
	void Start () {
        GameObject tmp = (GameObject)Instantiate(m_EnemyPrefab, transform.position, Quaternion.identity);
        tmp.transform.parent = transform;
        m_Head = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Head && m_ShotPossible)
            Fire();
	}

    void OnHead()
    {
        m_Head = true;
    }

    
}
