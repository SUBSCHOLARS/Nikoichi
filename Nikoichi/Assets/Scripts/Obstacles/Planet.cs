using UnityEngine;

public class Planet : MonoBehaviour
{
    public string targetTag = "OtherPart";
    public float gravityStrength = 3f;

    void Start()
    {
    
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
