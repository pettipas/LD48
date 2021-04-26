using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoPeeks : MonoBehaviour
{
   public Transform triggerHeight;
   public Animator animator;

   public AudioSource sound;

   public void OnEnable() {
       sound.Play();
       animator.enabled = true;
   }
}