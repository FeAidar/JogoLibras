using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class touchManege : MonoBehaviour
{
    Vector3 touchPosWorld;
    NewControls inpu;
    private Camera cameramain;
    void Awake()
    {
        cameramain = Camera.main;
        inpu = new NewControls();
        inpu.Inputs.Enable();
        inpu.Inputs.Touch.performed += TouchCart;
    }

    public void TouchCart(InputAction.CallbackContext ctx){

        if(ctx.performed){
            touchPosWorld = inpu.Inputs.TouchPosition.ReadValue<Vector2>();
            Vector3 touchPosWorld2D = new Vector3(touchPosWorld.x, touchPosWorld.y, cameramain.nearClipPlane);
            Vector3 worldPos = cameramain.ScreenToWorldPoint(touchPosWorld2D);
            worldPos.z = 0;
            RaycastHit2D hitInformation = Physics2D.Raycast(worldPos, Camera.main.transform.forward);
            if (hitInformation.collider != null) {
                GameObject touchedObject = hitInformation.transform.gameObject;
                if(touchedObject.tag.Equals("Cartas")){
                    if(touchedObject.GetComponent<testandoClick>() != null){
                        touchedObject.GetComponent<testandoClick>().vira();
                    }
                }
            }
        }
    }
}
