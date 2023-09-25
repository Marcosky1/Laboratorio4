using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoSeguir : MonoBehaviour
{
    public float velocidadMovimiento = 5f;
    public float distanciaDeteccion = 10f;
    public Transform jugador;
    private Rigidbody rb;
    private bool moviendoseHaciaJugador = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Si el jugador está dentro de la distancia de detección
        if (EstaJugadorEnRango())
        {
            // Calcula la dirección hacia el jugador
            Vector3 direccion = (jugador.position - transform.position).normalized;

            // Mueve al enemigo hacia el jugador
            rb.velocity = new Vector3(direccion.x * velocidadMovimiento, rb.velocity.y, direccion.z * velocidadMovimiento);
            moviendoseHaciaJugador = true;
        }
        else if (moviendoseHaciaJugador)
        {
            // Si ya se estaba moviendo hacia el jugador, detén el movimiento
            rb.velocity = Vector3.zero;
            moviendoseHaciaJugador = false;
        }
    }

    private bool EstaJugadorEnRango()
    {
        return Vector3.Distance(jugador.position, transform.position) <= distanciaDeteccion;
    }
}
