using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float gravityStrength = 100f;
    public float eventHorizonRadius = 1f;

    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("OtherPart");

        foreach (GameObject obj in objects)
        {
            Rigidbody2D rb2D = obj.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direction = (transform.position - obj.transform.position).normalized;
                float distance = Vector2.Distance(transform.position, obj.transform.position);

                float gravityForce = gravityStrength / (distance * distance);

                rb2D.AddForce(direction * gravityForce * Time.deltaTime);

                if (distance <= eventHorizonRadius)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
