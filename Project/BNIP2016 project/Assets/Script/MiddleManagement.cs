using UnityEngine;
using System.Collections;

public class MiddleManagement : MonoBehaviour {
    int ChildNum;
    GameObject[] Children;
    GameObject HeadObj;
    [SerializeField]
    GameObject CheckPoint;

	// Use this for initialization
	void Start () {
        ChildNum = transform.childCount;
        Children = new GameObject[ChildNum];
        for(int nCnt = 0; nCnt < ChildNum; nCnt++)
        {
            Children[nCnt] = transform.GetChild(nCnt).gameObject;
        }
	}
	
	// Update is called once per frame
	void Update () {
        HeadSearch();
        CalculationOrder();
	}

    void HeadSearch()
    {
        float Z = -100;
        int HeadNumber = -1;
        for (int nCnt = 0; nCnt < ChildNum; nCnt++)
        {
            if (Children[nCnt].transform.parent != null)
            {
                if (Z < Children[nCnt].transform.position.z)
                {
                    Z = Children[nCnt].transform.position.z;
                    HeadNumber = nCnt;
                }
            }
        }
        HeadObj = Children[HeadNumber];
        Children[HeadNumber].SendMessage("OnHead");
    
    }

    void CalculationOrder()
    {
        if (CheckPoint.GetComponent<CheckTraffic>().GetOnTraffic())
        {
            HeadObj.SendMessage("ShotRateCalculation");
            CheckPoint.GetComponent<CheckTraffic>().ResetOnTraffic();
        }
    }
}
