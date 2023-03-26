/*
 * Desc     : Membuat fungsi untuk menjalankan player berdasarkan posisi xyz
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_FPSController : MonoBehaviour
{

    [Header("Main Settings")]
    public CharacterController TargetPlayer;
    public Camera TargetCamera;
    public float PlayerSpeed;
    public float JumpSpeed;
    public float Gravity;
    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pemeriksaan jika karakter menyentuh tanah, isGrounded adalah variabel bawaan Character Controller
        if (TargetPlayer.isGrounded)
        {

            //cek input keyboard GetAxis(Horizontal & Vertical) dapat diatur di Input Setting
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            //arahkan player sesuai dengan hasil input
            moveDirection = TargetCamera.transform.TransformDirection(moveDirection);
            moveDirection *= PlayerSpeed;

            //tambahkan fungsi meloncat 
            if (Input.GetButton("Jump"))
                moveDirection.y = JumpSpeed;

        }
        //tambahkan efek gravitasi
        moveDirection.y -= Gravity * Time.deltaTime;

        //pasang hasil pergerakan ke karakter
        TargetPlayer.Move(moveDirection * Time.deltaTime);
    }
}
