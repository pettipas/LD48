using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoState : MonoBehaviour
{
    public InputControl Control;

    public void Awake(){
        Control = GetComponent<InputControl>();
    } 

}
