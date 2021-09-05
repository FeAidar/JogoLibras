using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody Shepre;
    private PlayerInput PlayerInput;
    private PlayerInputs playerInputActions;
    private void Awake(){
        Shepre = GetComponent<Rigidbody>();
        PlayerInput = GetComponent<PlayerInput>();

        playerInputActions = new PlayerInputs();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Jump.performed += Jump;
    }

    private void FixedUpdate(){
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        float speed = 10f;
        Shepre.AddForce(new Vector3(inputVector.x , 0 , inputVector.y)*speed*Time.deltaTime, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext ctx){
        if(ctx.performed){
            Debug.Log("Jump!" + ctx.phase);
            Shepre.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}
