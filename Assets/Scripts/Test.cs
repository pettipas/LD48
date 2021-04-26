using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public Death death;
    // Start is called before the first frame update
    void OnEnable()
    {
        death.GotoState();
    }

}
