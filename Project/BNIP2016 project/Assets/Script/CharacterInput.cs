using UnityEngine;
using System.Collections;

public class CharacterInput : MonoBehaviour {
    private Vector3 StartPos;       //タッチした始点
    private Vector3 MovePos;        //スワイプした時の座標
    private Vector3 PreMovePos;     //前の移動座標
    private Vector3 EndPos;         //タッチした終点
    private Enemy enemy;
    // Rayを飛ばすカメラ
    private Camera myCamera;
    // Ray
    private Ray ray;
    // Rayがヒットしたものの情報 
    private RaycastHit hit;
    // RayがヒットしたGameObjectを格納
    public static GameObject selectedGameObject;
    public int phase;


    // Use this for initialization
    void Start () {
        //----- 初期化初期化 ------
        StartPos = Vector3.zero;
        MovePos = Vector3.zero;
        PreMovePos = Vector3.zero;
        EndPos = Vector3.zero;

        myCamera = Camera.main;
        phase = 0;
    }
	
	// Update is called once per frame
	/// <summary>
    /// </summary>
    void Update () {
        //タッチがあったら
        if (Input.touchCount > 0) // && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Touch touch = Input.GetTouch(0);
            switch(touch.phase)
            {
                case TouchPhase.Began:
                    StartPos = touch.position;
                    // タッチの位置からRayを発射
                    ray = myCamera.ScreenPointToRay(Input.touches[0].position);
                    if (touch.phase == TouchPhase.Began && Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
                    {
                        // RayがヒットしたGameObjectをstaticなクラス変数に格納
                        selectedGameObject = hit.collider.gameObject;
                    }
                    else if (touch.phase == TouchPhase.Began && !Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
                    {
                        selectedGameObject = null;
                    }
                    phase = 1;
                    break;

                case TouchPhase.Moved:
                    Vector3 Pos;
                    Pos.x = touch.position.x;
                    Pos.y = touch.position.y;
                    Pos.z = 0.0f;

                    PreMovePos = MovePos;
                    MovePos = Pos - StartPos;       //スワイプした距離
                    phase = 2;
                    break;

                case TouchPhase.Ended:
                    EndPos = touch.position;

                    //------- タッチしたのがギャラガなら ------
                    if (LayerMask.LayerToName(selectedGameObject.layer) == "Galaga")
                    {
                       
                        //敵を移動させる
                        if (StartPos != EndPos)     //タップしたところから動いてなかったら飛ばす
                        {
                            Swipe();    //スワイプされた時の処理
                        }

                        //タップしたオブジェクトを解放
                        selectedGameObject = null;
                    }
                    phase = 3;
                    break;
            }
        }
     }

    //------ 二点間の角度を求める ------
    public float GetRadian(float x1, float y1, float x2, float y2)
    {
        
        float radian = Mathf.Atan2(y2 - y1, x2 - x1);
        return radian;
    }

    //------ スワイプされたら呼ぶ -------
    public void Swipe()
    {
        float Radian;       //角度
        Radian = GetRadian(StartPos.x, StartPos.y, EndPos.x, EndPos.y);     //角度を求める
        Vector3 Vec = Vector3.zero;     //向き
        Vec.x = Mathf.Cos(Radian);
        Vec.y = 0.0f;
        Vec.z = Mathf.Sin(Radian);
        Vector3 accele;     //加速度
        accele = MovePos - PreMovePos;
        accele.z = accele.y;
        accele.y = 0.0f;

        //敵の移動
        selectedGameObject.SendMessage("Rush");

    }
    public int GetPhase()
    {

        return phase;

    }

}
