using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
    public GameObject endPrefab;
    public GameObject startPrefab;
    public GameObject mysteryPefab;
    public List<Chunk> chunks = new List<Chunk>();
    public Transform startPosition;
    public void Awake() {
        startPrefab.Duplicate(startPosition);
        startPosition.position-=new Vector3(0,20,0);

        for(int i = 0; i < 16; i++){
            if(i == 8){
                mysteryPefab.Duplicate(startPosition);
                startPosition.position-=new Vector3(0,20,0);
            }
            chunks.GetRandomElement().Duplicate(startPosition);
            startPosition.position-=new Vector3(0,20,0);
        }
        
        endPrefab.Duplicate(startPosition);
    }
}
