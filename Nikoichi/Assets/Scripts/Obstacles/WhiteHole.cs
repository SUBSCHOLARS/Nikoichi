using UnityEngine;

public class WhiteHole : MonoBehaviour
{
    public float repulsionStrength = 100f;

    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("OtherPart");

        foreach (GameObject obj in objects)
        {
            Rigidbody2D rb2D = obj.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direction = (obj.transform.position - transform.position).normalized; // Reverse direction to push away
                float distance = Vector2.Distance(transform.position, obj.transform.position);

                float repulsionForce = repulsionStrength / (distance * distance);

                rb2D.AddForce(direction * repulsionForce * Time.deltaTime);

            }
        }
    }
}
