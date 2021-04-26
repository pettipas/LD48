using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    public List<MeshRenderer> pupils = new List<MeshRenderer>();

    public void Start() {
        StartCoroutine(SwitchPupils());
    }

    public IEnumerator SwitchPupils() {
        foreach(var p in pupils){
            p.enabled = false;
        }
        pupils.GetRandomElement().enabled = true;
        yield return new WaitForSeconds(Random.Range(2.0f, 5.0f));
        yield return StartCoroutine(SwitchPupils());
    }

}
