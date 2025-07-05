using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Planet : MonoBehaviour
{
    public string targetTag = "OtherPart";
    public float baseGravityStrength = 0.2f;
    public float minSize = 2.0f;
    public float maxSize = 3f;

    private float gravityStrength;

    void Start()
    {
        float randomScale = Random.Range(minSize, maxSize);
        transform.localScale = new Vector3(randomScale, randomScale, 1f);

        gravityStrength = baseGravityStrength * randomScale * randomScale;
        Debug.Log("GravityStrength: " + gravityStrength);
    }


    void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objects)
        {
            Rigidbody2D rb2D = obj.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direction = (transform.position - obj.transform.position).normalized;
                float distance = Vector2.Distance(transform.position, obj.transform.position);

                if (distance > 0.1f)
                {
                    float forceMagnitude = gravityStrength / (distance * distance);
                    rb2D.AddForce(direction * forceMagnitude);
                }
            }
        }
    }
}
