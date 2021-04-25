using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour
{
    public GameObject endPrefab;
    public GameObject prefab2x2;
    public GameObject prefab1x1;
    public List<Chunk> chunks = new List<Chunk>();
    public Transform startPosition;
    public void Awake(){
        for(int i = 0; i < 17; i++){
            chunks.GetRandomElement().Duplicate(startPosition);
            startPosition.position-=new Vector3(0,20,0);
        }
        endPrefab.Duplicate(startPosition);
    }
}
