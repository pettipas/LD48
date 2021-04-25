using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoState
{
    public float fallSpeed = 1;
    public float horizontalSpeed = 1;

    public void LateUpdate() {
        Vector3 n = Control.LatestDirection;
        Vector3 fallStep = new Vector3(0, -1, 0) * Time.deltaTime * fallSpeed;
        Control.Mover.Move(fallStep);
    }
}
