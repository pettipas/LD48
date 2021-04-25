using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoPeeks : MonoBehaviour
{
   public Transform triggerHeight;
   public Animator animator;
   public void OnEnable(){
       animator.enabled = true;
   }
}