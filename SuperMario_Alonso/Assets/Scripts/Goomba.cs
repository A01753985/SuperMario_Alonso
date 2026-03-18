using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] private float VelocityX;
    [SerializeField] private Rigidbody2D rb;    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VelocityX = 1.5f;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocityX = -VelocityX;
        
    }
}
