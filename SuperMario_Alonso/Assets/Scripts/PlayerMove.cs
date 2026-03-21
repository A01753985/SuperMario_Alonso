using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    
    // Declarar variables
    [SerializeField] private float VelocityX;           //Velocidad horizontal
    [SerializeField] private float jumpSpeed;           //Velociad vertical
    [SerializeField] private bool isGrounded;           //Booleano de si está en el piso el personaje
    [SerializeField] private Rigidbody2D rb;            //Rigidbody
    [SerializeField] private InputAction jump;          //Evento de InputAction para brincar
    [SerializeField] private InputAction moveAction;    //Evento de InputAction para mover
    [SerializeField] private Animator anim;    //Controlador de animación
    [SerializeField] private SpriteRenderer sprite;    //Controlador de sprite

    void Start()
    {

        //Asignar valores iniciales
        VelocityX = 5f;
        jumpSpeed = 7f;
        isGrounded = true;
        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
        //Activar eventos de Input Action
        jump.Enable();
        moveAction.Enable();

        
    }

    // Update is called once per frame
    void Update()
    {

        // Mover izquierda o derecha
        Vector2 movement = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = new Vector2(movement.x * VelocityX, rb.linearVelocityY);

        //Checar si el personaje esta en el piso con un BoxCast
        isGrounded = Physics2D.BoxCast(transform.position, new Vector2(0.4f, 0.1f), 0f, Vector2.down, 0.22f, LayerMask.GetMask("Ground"));

        //Brincar si se detecta el evento de brincar y el personaje esta en el piso
        if (jump.WasPressedThisFrame() && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, 1 * jumpSpeed);
        }

        // Voltear sprite si se cambia de dirección
        if (movement.x < 0)
        {
            sprite.flipX = true;
        } else if (movement.x > 0)
        {
            sprite.flipX = false;
        }
        
        // Cambiar variables del animator controller
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speedX", Mathf.Abs(movement.x));
    }
}
