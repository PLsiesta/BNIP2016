using UnityEngine;
using System.Collections;

public class Enemy : UnitBase {
    
    public GameObject m_EnemyPrefab;
    [SerializeField]
    bool    m_Head;

	// Use this for initialization
	void Start () {
        m_Head = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (m_Head && m_ShotPossible)
            Fire();
        m_PrevPosition = transform.position;
	}

    void OnHead()
    {
        m_Head = true;
    }

    
}
