using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTrans;
    public Vector3 offset;

    void Update()
    {
        transform.position = playerTrans.position + offset;
    }
}
