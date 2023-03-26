/*
 * Desc     : Membuat fungsi untuk menjalankan player berdasarkan posisi xyz
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_FPSTranslate : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetPlayer;
    public Camera TargetCamera;
    public float PlayerSpeed;
    public KeyCode UpArrow = KeyCode.UpArrow;
    public KeyCode LeftArrow = KeyCode.LeftArrow;
    public KeyCode DownArrow = KeyCode.DownArrow;
    public KeyCode RightArrow = KeyCode.RightArrow;
    public KeyCode W = KeyCode.W;
    public KeyCode A = KeyCode.A;
    public KeyCode S = KeyCode.S;
    public KeyCode D = KeyCode.D;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //deteksi penekanan keyboard
        if (Input.GetKey(UpArrow) || Input.GetKey(W))
        {
            //gunakan fungsi translate untuk bergerak berdasarkan arah vector
            TargetPlayer.transform.Translate(Vector3.forward * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(LeftArrow) || Input.GetKey(A))
        {
            TargetPlayer.transform.Translate(Vector3.left * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(DownArrow) || Input.GetKey(S))
        {
            TargetPlayer.transform.Translate(Vector3.back * PlayerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(RightArrow) || Input.GetKey(D))
        {
            TargetPlayer.transform.Translate(Vector3.right * PlayerSpeed * Time.deltaTime);
        }
    }
}
