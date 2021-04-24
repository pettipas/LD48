using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public MonoState defaultState;
    public MonoState gameOver;
    public GameObject body;
    public Vector3 LatestDirection;
    public Vector3 LastGoodRawDirection;
    public Vector3 LastGoodDirection;
    public CharacterController Mover;
    public Transform oceanFloor;
    public Transform cameraTransform;
    public bool DashPressed;

    public void Awake () {
        gameOver = GetComponent<GameOver>();
        defaultState = GetComponent<FreeFall>();
        defaultState.GotoState();
        Mover = GetComponent<CharacterController>();
        body.transform.forward = Vector3.left;
    }

    public void Update(){

        if(transform.position.y < oceanFloor.position.y){
            cameraTransform.SetParent(null);
            gameOver.GotoState();
            this.enabled = false;
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float xR = Input.GetAxisRaw("Horizontal");
        LatestDirection = new Vector3(x, 0, 0);

        if(x > 0 || x < 0){
            LastGoodDirection = new Vector3(x, 0, 0);
        }

        if(xR > 0 || xR < 0){
            LastGoodRawDirection = new Vector3(xR, 0, 0);
            body.transform.forward = LastGoodRawDirection;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            DashPressed = true;
        }else{
            DashPressed = false;
        }
    }
}
