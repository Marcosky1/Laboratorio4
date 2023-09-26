using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform jugador;
    public Vector3 posicionInicial = new Vector3(-3.09f, 1f, -10.56f);
    public CinemachineImpulseSource impulseSource; 
    public float intensidadVibracion = 1.0f; 

    void Start()
    {
        // Establecer la posición inicial de la cámara
        transform.position = new Vector3(posicionInicial.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (jugador != null)
        {
            Vector3 nuevaPosicion = transform.position;
            nuevaPosicion.x = jugador.position.x;
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

    public void HacerCamaraTiemblar()
    {
        if (impulseSource != null)
        {
            impulseSource.GenerateImpulse();
        }
    }
}


