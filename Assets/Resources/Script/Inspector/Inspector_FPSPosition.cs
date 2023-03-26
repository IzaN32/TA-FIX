/*
 * Desc     : Membuat fungsi untuk menjalankan player berdasarkan posisi xyz
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_FPSPosition : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetPlayer;
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
            //mengambil nilai posisi player, dimasukan ke variabel temprorer
            Vector3 temp = TargetPlayer.transform.position;
            //tambah nilai z dengan speed
            temp.z += PlayerSpeed * Time.deltaTime;
            //pasang nilai hasil penambahan ke posisi player
            TargetPlayer.transform.position = temp;
        }
        if (Input.GetKey(LeftArrow) || Input.GetKey(A))
        {
            Vector3 temp = TargetPlayer.transform.position;
            temp.x -= PlayerSpeed * Time.deltaTime;
            TargetPlayer.transform.position = temp;
        }
        if (Input.GetKey(DownArrow) || Input.GetKey(S))
        {
            Vector3 temp = TargetPlayer.transform.position;
            temp.z -= PlayerSpeed * Time.deltaTime;
            TargetPlayer.transform.position = temp;
        }
        if (Input.GetKey(RightArrow) || Input.GetKey(D))
        {
            Vector3 temp = TargetPlayer.transform.position;
            temp.x += PlayerSpeed * Time.deltaTime;
            TargetPlayer.transform.position = temp;
        }
    }
}
