using UnityEngine;
using System.Collections;


public enum UNIT_TYPE
{
    FIGHTER,
    GALAGA
}

public class UnitBase : MonoBehaviour {


    public GameObject BulletObj;
    protected Vector3 m_PrevPosition;
    protected bool  m_ShotPossible;
    [SerializeField]
    protected float m_ShotRate;
    [SerializeField]
    protected float m_Hp;
    [SerializeField]
    protected float m_BulletDPS;
    [SerializeField]
    protected Vector3 m_BulletSpeed;
    [SerializeField]
    protected Vector3 m_MoveSpeed;
    [SerializeField]
    protected UNIT_TYPE m_UnitType; 


	// Use this for initialization
	void Start () {
        m_ShotPossible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void Fire()
    {
        GameObject tmpBullet = (GameObject)Instantiate(BulletObj, transform.position, BulletObj.transform.rotation);
        tmpBullet.GetComponent<BulletData>().SetData(m_BulletSpeed, m_BulletDPS, m_UnitType);
        m_ShotPossible = false;
    }

    protected void ShotRateCalculation()
    {
        if (m_ShotRate > Random.Range(0.0f, 10.0f))
            m_ShotPossible = true;
    }

    public float GetHp()
    {

       return m_Hp;
    
    }

}
