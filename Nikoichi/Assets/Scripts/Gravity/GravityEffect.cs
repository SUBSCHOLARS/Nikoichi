using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(LineRenderer))]
public class GravityEffect : MonoBehaviour
{
    //Unityエディタから調整できるパラメータ
    [Range(10, 100)]
    //円を構成する頂点の数。多いほど滑らかになる。
    [SerializeField] private int segments = 50;
    //基本となる円の半径
    [SerializeField] private float baseRadius = 1.0f;
    [Header("脈動エフェクト")]
    [SerializeField] private float pulseSpeed = 1.0f;
    [SerializeField] private float pulseAmplitude = 0.2f;
    [Header("波形ノイズ")]
    [SerializeField] private float noiseStrength = 0.1f;
    [SerializeField] private float noiseSpeed = 10.0f;

    private LineRenderer lineRenderer;
    private Camera mainCamera;

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        mainCamera = Camera.main;
        //頂点数を設定
        lineRenderer.positionCount = segments;
        // このレンダラーが使用するマテリアルのレンダーキューを
        // 「Overlay（UIなどが使う描画順）」に設定する
        GetComponent<Renderer>().material.renderQueue = (int)RenderQueue.Overlay;
    }
    //LateUpdateを使うことで、全Update処理が終わった後に処理を呼び出すことが可能になり、カーソルの追従が可能になる。
    void LateUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            //描画を有効にする
            lineRenderer.enabled = true;

            //マウス位置にエフェクト移動
            Vector2 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mouseWorldPos;

            //円を描画・更新
            DrawPulsatingCircle();
        }
        else
        {
            //描画を無効にする
            lineRenderer.enabled = false;
        }
        
        
    }
    void DrawPulsatingCircle()
    {
        //1. サイン波で現在の脈動半径を計算
        float currentPulse = Mathf.Sin(Time.time * pulseSpeed) * pulseAmplitude;
        float pulsatingRadius = baseRadius + currentPulse;

        //2. 円の拡張点を計算して設定
        for (int i = 0; i < segments; i++)
        {
            //角度の計算
            float angle = ((float)i / (float)segments) * 2 * Mathf.PI;

            //3. パーリンノイズで半径に揺らぎを追加
            //XとYにTime.timeを加えることでノイズが時間で変化し、炎のようにゆらめく
            float noise = Mathf.PerlinNoise(Mathf.Cos(angle) + Time.time * noiseSpeed, Mathf.Sin(angle) + Time.time * noiseSpeed);
            float radiusWithNoise = pulsatingRadius + noise * noiseStrength;

            //X, Y座標を計算
            float x = Mathf.Cos(angle) * radiusWithNoise;
            float y = Mathf.Sin(angle) * radiusWithNoise;

            //LineRendererの頂点位置を設定
            lineRenderer.SetPosition(i, new Vector3(x, y, 0f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
