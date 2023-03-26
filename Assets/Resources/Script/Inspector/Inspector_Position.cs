/*
 * Desc     : Membuat fungsi untuk melakukan posisi pada suatu objek
 * Author   : Rickman Roedavan
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Position : MonoBehaviour
{
    [Header("Main Settings")]
    public GameObject TargetObject;
    public Vector3 ParameterVector;

    // Start is called before the first frame update
    void Start()
    {
        //memasangkan nilai pada gameobject
        TargetObject.transform.position = ParameterVector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
