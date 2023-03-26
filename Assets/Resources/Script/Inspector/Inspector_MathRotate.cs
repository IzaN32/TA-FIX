/*
 * Desc     : Membuat fungsi untuk melakukan rotasi pada suatu objek secara runtime
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_MathRotate : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetObject;
    public Vector3 RotationVector;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // memasangkan nilai pada gameobject
        TargetObject.transform.Rotate(RotationVector * Time.deltaTime);
    }
}
