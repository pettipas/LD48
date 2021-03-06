using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControl : MonoBehaviour
{
    public MonoState defaultState;
    public MonoState gameOver;
    public GameObject body;
    public Vector3 LatestDirection;
    public Vector3 LastGoodDirection;
    public CharacterController Mover;
    public OceanFloor oceanFloor;
    public Transform cameraTransform;
    public bool DashPressed;
    public bool DownPressed;

    public MonoState Dash;

    public int fishEaten;
    
    public void Awake () {
        fishEaten = 0;
        gameOver = GetComponent<GameOver>();
        oceanFloor = GameObject.FindObjectOfType<OceanFloor>();
        defaultState = GetComponent<FreeFall>();
        defaultState.GotoState();
        Mover = GetComponent<CharacterController>();
        body.transform.forward = Vector3.left;
    }

    public void Start(){

    }

    public void Update(){

        if(transform.position.y < oceanFloor.camDepth.position.y) {
            gameOver.GotoState();
            this.enabled = false;
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            DashPressed = true;
        }else{
            DashPressed = false;
        }

        float y = Input.GetAxis("Vertical");
        float yR = Input.GetAxisRaw("Vertical");

        float x = Input.GetAxis("Horizontal");
        float xR = Input.GetAxisRaw("Horizontal");
        
        if(y < 0 && !Dash.enabled) {
            LatestDirection = new Vector3(0, y, 0);
            body.transform.eulerAngles = new Vector3(90,90,0);
            DownPressed = true;
            return;
        }else {
            DownPressed = false;
        }

        LatestDirection = new Vector3(x, 0, 0);

        if(x > 0 || x < 0){
            LastGoodDirection = new Vector3(x, 0, 0);
        }

        if(xR > 0 || xR < 0 && !Dash.enabled){
            body.transform.eulerAngles = new Vector3(0,90*xR,0);
        }
    }
}
