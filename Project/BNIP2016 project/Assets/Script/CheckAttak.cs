using UnityEngine;
using System.Collections;

public class CheckAttak : ThinkingBase {

    bool m_HitObjBullet;
    bool m_HitObjEnemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public override ThinkingBase Thinking(GameObject Body)
    {
        ThinkingBase tmp;
        //攻撃されていたら
        if (m_HitObjEnemy || m_HitObjBullet)
            tmp = m_NextModules[0].Thinking(Body);
        else
            tmp = m_NextModules[1].Thinking(Body);

        m_HitObjEnemy = m_HitObjBullet = false;
        return tmp;
    }

    void OnTriggerEnter(Collider Coll)
    { 
        if(Coll.tag == "GalagaBullet")
            m_HitObjBullet = true;
        if (LayerMask.LayerToName(Coll.gameObject.layer) == "Galaga")
            m_HitObjEnemy = true;           
            
    }
}
