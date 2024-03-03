using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    private MenuManager cheese;
    private Move actions;
    private InputAction move;
    private InputAction jump;
    private InputAction exit;


    private Rigidbody rb;
    [SerializeField]private float speed = 1000f;
    [SerializeField]private float turnSpeed = 1000f;
    [SerializeField]private Transform position;
    private Vector2 vel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cheese = new MenuManager();
        actions = new Move();
    }
    private void OnEnable()
    {
        move = actions.Player.Move;
        move.Enable();
        jump = actions.Player.Jump;
        jump.performed += Jumped;
        jump.Enable();
        exit = actions.Player.Exit;
        exit.performed += Exit;
        exit.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
        jump.performed -= Jumped;
        jump.Disable();
    }
    private void FixedUpdate()
    {
        Vector2 moveD = move.ReadValue<Vector2>();
        vel.x = turnSpeed * moveD.x * 10000;
        vel.y = speed * moveD.y * 10000;
        rb.AddForce(transform.forward * vel.y * Time.deltaTime);
        rb.AddForceAtPosition(transform.right * vel.x * Time.deltaTime, position.position);
    }
    private void Jumped(InputAction.CallbackContext context)
    {
        Debug.Log("bu");
        rb.AddForce(transform.up * 250f, ForceMode.Impulse);
    }
    private void Exit(InputAction.CallbackContext context){
        cheese.LoadScene();
    }
}
