using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoState
{
    public Animator camerAnimator;

    public Transform target;
    public AudioSource deathSound;
    public void OnEnable() {
        StartCoroutine(HandleDeath());
    }

    public void Update(){

    }

    public IEnumerator  HandleDeath(){
        
        followCam.SetParent(null);
        Vector3 start = followCam.position;
        Vector3 end = new Vector3(target.position.x,target.position.y,followCam.position.z); 
       
        followCam.position = end;
        camerAnimator.SafePlay("death_zoom",0,0);
        deathSound.Play();
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("main");

        yield break;
    } 

}
