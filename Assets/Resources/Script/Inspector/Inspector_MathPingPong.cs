/*
 * Desc     : Membuat fungsi untuk melakukan transisi ping-pong pada suatu objek
 * Author   : Rickman Roedavan
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_MathPingPong : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetObject;
    public Vector3 ParameterVector;
    public float PingPongSpeed;
    Vector3 StartPosition;
    Vector3 EndPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = TargetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // memasangkan nilai pada gameobject
        float pingPong = Mathf.PingPong(Time.time * PingPongSpeed, 1);
        EndPosition = StartPosition + ParameterVector;
        TargetObject.transform.position = Vector3.Lerp(StartPosition, EndPosition, pingPong);
    }
}
