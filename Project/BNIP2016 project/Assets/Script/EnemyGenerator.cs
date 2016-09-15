using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    public GameObject[] EnemyList;      //生成する敵のオブジェクト
    [SerializeField]
    int BossNum;                        //ボスの生成数
    [SerializeField]
    int GoeiNum;                        //護衛の生成数
    [SerializeField]
    int ZakoNum;                        //雑魚の生成数

	// Use this for initialization
	void Start () {

        //int[] nEnemyNum = {BossNum,GoeiNum,ZakoNum};        //各種敵の生成数
        //Vector3 StartPosition = new Vector3(-5.0f,10.0f, -18.0f);


        //for (int nEnemyType = 0; nEnemyType < 3; nEnemyType++)
        //{
        //    Vector3 CreatePosition = StartPosition;
        //    for (int nCreateCnt = 0; nCreateCnt < nEnemyNum[nEnemyType]; nCreateCnt++)
        //    {
        //        Instantiate(EnemyList[nEnemyType], CreatePosition, Quaternion.identity);
        //        CreatePosition.x += 2.5f;
        //    }
        //    StartPosition.z += 2.5f;
        //}
	}
	
	// Update is called once per frame
	void Update () {
	
	}




}
