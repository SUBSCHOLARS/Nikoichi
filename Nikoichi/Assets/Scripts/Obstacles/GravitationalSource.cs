using UnityEngine;

public abstract class GravitationalSource : MonoBehaviour
{
    public float strength = 10f;
    public float minDistance = 0.1f;
    public string targetTag = "OtherPart";

    protected virtual void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);

        foreach (GameObject obj in objects)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb == null) continue;

            Vector2 direction = GetDirection(obj);
            float distance = Vector2.Distance(transform.position, obj.transform.position);
            if (distance < minDistance) continue;

            float force = strength / (distance * distance);
            ApplyForce(rb, direction, force, distance, obj);
        }
    }

    // Each subclass defines the direction of the force
    protected abstract Vector2 GetDirection(GameObject obj);

    // Each subclass can customize how the force is applied (or destruction)
    protected virtual void ApplyForce(Rigidbody2D rb, Vector2 direction, float force, float distance, GameObject obj)
    {
        rb.AddForce(direction * force * Time.deltaTime);
    }
}
