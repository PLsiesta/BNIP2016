using UnityEngine;
using System.Collections;

//************************************
// MiddleManement
//
// 主に縦の隊列の管理を行うクラス　
// 縦隊列の先頭を検索したりしてるよ？
// 
//
//************************************


public class MiddleManagement : MonoBehaviour {

    GameObject[] Children;          //縦隊列内のギャラガ確保用配列
    public GameObject[] GalagaList; //生成するギャラガの種類（0：ボス　1:ゴエイ　2:ザコ）
    GameObject HeadObj;             //各縦隊列の先頭のギャラガ
    
    [SerializeField]                
    GameObject CheckPoint;          //戦闘のギャラガが弾を発射するかを思考するためのチェックポイント


/////////////////////////////////////
// 初期化
////////////////////////////////////
	void Start () {
        Children = new GameObject[3];
            for (int nNum = 0; nNum < 3; nNum++)
            {
                Children[nNum] = (GameObject)Instantiate(GalagaList[nNum],
                            new Vector3(transform.position.x, transform.position.y, transform.position.z - nNum * 3),
                            GalagaList[nNum].transform.rotation);
                Children[nNum].transform.parent = transform;
            }
	}

/////////////////////////////////////
// 更新
////////////////////////////////////

	void Update () {
        HeadSearch();
        CalculationOrder();
	}

/////////////////////////////////////
//　縦隊列内の先頭を検索
////////////////////////////////////
    void HeadSearch()
    {
        float Z = -100;
        int HeadNumber = -1;
        for (int nCnt = 0; nCnt < 3; nCnt++)
        {
                if (Z < Children[nCnt].transform.position.z)
                {
                    Z = Children[nCnt].transform.position.z;
                    HeadNumber = nCnt;
                }
        }
        HeadObj = Children[HeadNumber];
        Children[HeadNumber].SendMessage("OnHead");
    
    }

/////////////////////////////////////
// 縦隊列内の先頭のギャラガに発射可否の思考を要求
////////////////////////////////////
    void CalculationOrder()
    {
        if (CheckPoint.GetComponent<CheckTraffic>().GetOnTraffic())
        {
            HeadObj.SendMessage("ShotRateCalculation");
            CheckPoint.GetComponent<CheckTraffic>().ResetOnTraffic();
        }
    }
}
