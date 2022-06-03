using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float smoothTime;

    [SerializeField] GameObject leftJoystick;
    [SerializeField] GameObject rightJoystick;

    CharacterController character;
    

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Debug.Log(leftJoystick.GetComponent<MobileJoystickController>().pointPosition.x);
        // Movimiento de traslación
        character.Move(
            Vector3.forward * leftJoystick.GetComponent<MobileJoystickController>().pointPosition.y * speed * Time.deltaTime
            +
            Vector3.right * leftJoystick.GetComponent<MobileJoystickController>().pointPosition.x * speed * Time.deltaTime
            );


        // Movimiento de rotación
        Vector3 desde = new Vector3(0.0f, 0.0f, 1.0f);
        Vector3 hacia = new Vector3(
            rightJoystick.GetComponent<MobileJoystickController>().pointPosition.x,
            0.0f,
            rightJoystick.GetComponent<MobileJoystickController>().pointPosition.y
            );
        float angulo = Vector3.SignedAngle(desde, hacia, Vector3.up);

        transform.eulerAngles = Vector3.up * Mathf.LerpAngle(transform.eulerAngles.y, angulo, smoothTime);
    }

}
