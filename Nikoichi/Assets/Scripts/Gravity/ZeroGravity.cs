using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//このスクリプトは、オブジェクトの無重力状態を視覚的に表現するためのものです。
public class ZeroGravity : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 1.0f;
    [SerializeField] private float floatAmplitude=0.1f;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
        //ゲーム開始時のY座標を保存
        this.startY=transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //sin波を計算して新しいY座標を求める
        //Time.timeを用いることで滑らかな運動を実現する
        float newY = startY + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;

        //オブジェクトのY座標を更新
        transform.position = new Vector2(transform.position.x, newY);   
    }
}
