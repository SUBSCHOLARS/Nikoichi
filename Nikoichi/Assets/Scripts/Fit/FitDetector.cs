using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//窪みにハマったことを検知するスクリプトです。
public class FitDetector : MonoBehaviour
{
    //どのくらい近づけばハマったとみなすかの距離
    [SerializeField] private float fitDistanceThreshold = 0.1f;
    //どのくらい遅ければ止まったとみなすかの速度
    [SerializeField] private float fitVelocityThreshold = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("OtherPart"))
        {
            //条件1 パーツの速度が十分い遅いか？
            bool isSlowEnough = other.GetComponent<Rigidbody2D>().velocity.magnitude < fitVelocityThreshold;
            //条件2 パーツの位置が十分近いか？
            float distance = Vector2.Distance(transform.position, other.transform.position);
            bool isCloseEnough = distance < fitDistanceThreshold;

            //二つの条件を満たしたらハマったと判定する
            if (isSlowEnough && isCloseEnough)
            {
                Debug.Log("フィットした！クリア！");
            }
        }
    }
}
