using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public Transform target;
    // public Vector3 offset;
    public Vector3 offset = new Vector3(0, 50, -500);


    private void LateUpdate(){
        Vector3 newPos= target.position + offset;
        newPos.z = transform.position.z;
        transform.position = newPos;

    
    }
} 