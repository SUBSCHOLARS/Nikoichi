using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    public float forceStreength = 100.0f;
    private Rigidbody2D rb2D;
    private Camera mainCamera;
    public static bool isGravityEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの左ボタンが長押しされている間だけ処理を行う
        if (Input.GetMouseButton(0))
        {
            isGravityEnabled = true;
            //1. マウスの座標をワールド座標に変換
            Vector3 mouseScreenPos = Input.mousePosition;
            //Z座標はカメラからの距離なので、適当な値を入れる
            mouseScreenPos.z = 10f;
            Vector2 targetPosition = mainCamera.ScreenToWorldPoint(mouseScreenPos);

            //2. マウスの座標から対象のオブジェクトの位置を引く、位置によって強さが変わらないよう正規化する
            Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
            //3. 計算した方向に力を加える
            rb2D.AddForce(direction * forceStreength * Time.deltaTime);
        }
        else
        {
            isGravityEnabled = false;
        }
    }
}
