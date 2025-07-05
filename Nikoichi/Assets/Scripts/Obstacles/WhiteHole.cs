using UnityEngine;

public class WhiteHole : MonoBehaviour
{
    public float repulsionStrength = 500f;

    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("OtherPart");

        foreach (GameObject obj in objects)
        {
            Rigidbody2D rb2D = obj.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direction = (obj.transform.position - transform.position).normalized;
                float distance = Vector2.Distance(transform.position, obj.transform.position);

                float repulsionForce = repulsionStrength / (distance * distance);

                if (distance <= 0.1f)
                {
                    repulsionForce = repulsionStrength;
                }

                rb2D.AddForce(direction * repulsionForce * Time.deltaTime);

            }
        }
    }
}
