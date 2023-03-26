/*
 * Desc     : Membuat fungsi untuk memutar camera berdasarkan mouse
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_MouseLook : MonoBehaviour
{

    [Header("Main Settings")]
    public Camera TargetCamera;
    public float Sensitivity;
    private float X;
    private float Y;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 euler = TargetCamera.transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;
    }

    // Update is called once per frame
    void Update()
    {
        const float minX = 0.0f;
        const float maxX = 360.0f;
        const float minY = -90.0f;
        const float maxY = 90.0f;

        X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (X < minX) X += maxX;
        else if (X > maxX) X -= maxX;
        Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
        if (Y < minY) Y = minY;
        else if (Y > maxY) Y = maxY;

        TargetCamera.transform.rotation = Quaternion.Euler(Y, X, 0.0f);
    }
}
