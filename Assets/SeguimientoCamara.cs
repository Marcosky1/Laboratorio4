using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform jugador;
    public Vector3 posicionInicial = new Vector3(-3.09f, 1f, -10.56f);

    void Start()
    {
        // Establecer la posición inicial de la cámara
        transform.position = new Vector3(posicionInicial.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (jugador != null)
        {
            // Obtener la posición actual de la cámara
            Vector3 nuevaPosicion = transform.position;
            // Actualizar solo la coordenada X con la posición del jugador
            nuevaPosicion.x = jugador.position.x;
            // Establecer la nueva posición de la cámara
            transform.position = nuevaPosicion;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Cambia la proyección de la cámara a perspectiva 3D
            Camera.main.orthographic = false;

            Camera.main.fieldOfView = 10f;
        }
    }
}

