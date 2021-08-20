using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private CharacterController _charCont;
    private ManagerJoyStick joystick;
    private float inputX;
    private float inputZ;
    private Vector3 v_movement;
    private Vector3 v_velocity;
    private float moveSpeed;
    private float gravity;



     void Start()
    {
        GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
        _charCont = tempPlayer.GetComponent<CharacterController>();

        moveSpeed = 7f;
        gravity = 0.5f;
        joystick = GameObject.Find("touchhold").GetComponent<ManagerJoyStick>();
    }
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        inputX = joystick.inputHorizontal();
        inputZ = joystick.inputVertical();

    }

    private void FixedUpdate()
    {
        v_movement = _charCont.transform.forward * inputZ;

        _charCont.transform.Rotate(Vector3.up * inputX * (100f * Time.deltaTime));

        _charCont.Move(v_movement * moveSpeed * Time.deltaTime);
    }
}
