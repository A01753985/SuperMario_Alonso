using UnityEngine;

public class Goomba : MonoBehaviour
{
    [SerializeField] private float VelocityX;       //Velocidad del goomb
    [SerializeField] private Rigidbody2D rb;        //Rigidbody
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Valores iniciales
        VelocityX = 1.5f;
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //Mover a la izquierda continuamente
        rb.linearVelocityX = -VelocityX;
        
    }
}
