using UnityEngine;
using System.Collections;

public class UnitBase : MonoBehaviour {

    public GameObject BulletObj;
    [SerializeField]
    protected bool m_ShotPossible;
    [SerializeField]
    protected float m_ShotRate; 

	// Use this for initialization
	void Start () {
        m_ShotPossible = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    protected void Fire()
    {
        Instantiate(BulletObj, transform.position, BulletObj.transform.rotation);
        m_ShotPossible = false;
    }

    protected void ShotRateCalculation()
    {
        if (m_ShotRate > Random.Range(0.0f, 10.0f))
            m_ShotPossible = true;
    }

}
