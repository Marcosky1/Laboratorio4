using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovimientoEnemigo : MonoBehaviour
{
    public float velocidadMovimiento = 2f; // Velocidad de movimiento horizontal del enemigo
    public int direccion = 1; // 1 para moverse hacia la derecha, -1 para moverse hacia la izquierda

    private void Update()
    {
        Vector3 movimiento = Vector3.right * velocidadMovimiento * direccion * Time.deltaTime;

        transform.Translate(movimiento);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el otro objeto tiene un collider que es un trigger
        if (other.isTrigger)
        {
            direccion *= -1;
        }
    }
}

