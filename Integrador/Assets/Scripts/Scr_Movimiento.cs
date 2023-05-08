using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Movimiento : MonoBehaviour
{
    public float velocidad;
    private float gravedad=9.8f;
    public float salto;
    public CharacterController jugador;
    public Camera Camara;
    private float horizontal;
    private float vertical;
    private Vector3 inputjugador;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movimientoJugador;
    void Start()
    {
        jugador=GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal=Input.GetAxis("Horizontal");
        vertical=Input.GetAxis("Vertical");
        inputjugador= new Vector3(horizontal,0,vertical);
        inputjugador= Vector3.ClampMagnitude(inputjugador, 1);

        direccioncamara();

        movimientoJugador = inputjugador.x * camRight + inputjugador.z * camForward;
        movimientoJugador = movimientoJugador * velocidad;
        jugador.transform.LookAt(jugador.transform.position+movimientoJugador);

        Gravedad();

        jugador.Move(movimientoJugador * Time.deltaTime);
    }

    void direccioncamara()
    {
        camForward= Camara.transform.forward;
        camRight= Camara.transform.right;
        camForward.y=0;
        camRight.y=0;

        camForward= camForward.normalized;
        camRight= camRight.normalized;
    }
    void Gravedad()
    {
            movimientoJugador.y = -gravedad;
    }
}

