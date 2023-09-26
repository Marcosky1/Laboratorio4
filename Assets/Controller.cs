using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private float speed = 5f;
    private float jumpForce = 8f;

    private Vector3 movimiento;
    private Rigidbody RB;
    private bool Jump;


    private LayerMask layer;
    private float rayDistance = 2f;
    private Color rayColor = Color.red;

    public int vida = 100;
    public int puntaje = 0;
    private Vector3 posicionInicial;

    public delegate void VidaPerdidaHandler(int cantidad);
    public event VidaPerdidaHandler OnVidaPerdida;



    void Start()
    {
        posicionInicial = transform.position;

        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        movimiento = new Vector3(Input.GetAxisRaw("Horizontal"),RB.velocity.y, Input.GetAxisRaw("Vertical"));
        
        Jump = Physics.Raycast(transform.position, Vector3.down, rayDistance, layer);

        Debug.DrawRay(transform.position, Vector3.down * rayDistance, rayColor);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        RB.velocity = Vector3.Scale(movimiento,new Vector3(speed,1,speed));
        

    }


    //Colisiones

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Muerte")
        {
            PerderVida(vida);
        }
        else if (other.CompareTag("Moneda"))
        {
            SumarPuntos(10);
            Destroy(other.gameObject);
        }
        
        else if (other.CompareTag("Corazon"))
        {
            SumarVida(50);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            PerderVida(20);
        }
    }



    private void PerderVida(int cantidad)
    {
        vida -= cantidad;
        if (vida <= 0)
        {
            vida = 100; // Restaura la vida a 100
            transform.position = posicionInicial; // Vuelve a la posición inicial
        }

        if (OnVidaPerdida != null)
        {
            OnVidaPerdida(cantidad);
        }
    }

    private void SumarPuntos(int cantidad)
    {
        puntaje += cantidad;
    }

    private void SumarVida(int cantidad)
    {
        vida += cantidad;
        vida = Mathf.Clamp(vida, 0, 100);
    }
}
