/*
 * Desc     : Membuat fungsi untuk pergerakan third person
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_ADVControllerAttack : MonoBehaviour
{

    [Header("Main Settings")]
    public CharacterController TargetPlayer;
    public Camera TargetCamera;
    public Animator TargetAnimator;
    public GameObject TargetWeapon;
    public float mouseSensitivity = 2f;
    public float PlayerSpeed;
    public float VerticalSpeed;
    public float JumpSpeed;
    public float Gravity;
    public float upLimit = -50;
    public float downLimit = 50;
    Vector3 moveDirection;

    [Header("Animation Settings")]
    public string AnimationWalkingState;
    public string AnimationAttackState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //variabel untuk pergerakan dan rotasi
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        //perubahan rotasi kamera dan karakter berdasarkan mouse
        TargetPlayer.transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        TargetCamera.transform.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        //clamp nilai rotasi 
        Vector3 currentRotation = TargetCamera.transform.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        TargetCamera.transform.localRotation = Quaternion.Euler(currentRotation);

        //cek nilai untuk kecepatan loncat/gravotasi
        if (TargetPlayer.isGrounded) VerticalSpeed = 0;
        else VerticalSpeed -= Gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, VerticalSpeed, 0);

        //buat variabel untuk maju ke depa
        Vector3 move = TargetPlayer.transform.forward * verticalMove + TargetPlayer.transform.right * horizontalMove;

        if (Input.GetButton("Jump")) move.y = JumpSpeed;
        TargetPlayer.Move(PlayerSpeed * Time.deltaTime * move + gravityMove * Time.deltaTime);

        //jalankan animasi sesuai dengan parameter
        TargetAnimator.SetBool(AnimationWalkingState, verticalMove != 0 || horizontalMove != 0);
        TargetAnimator.SetBool(AnimationAttackState, Input.GetKey(KeyCode.Mouse0));
        if (Input.GetKey(KeyCode.Mouse0))
        {
            TargetWeapon.SetActive(true);
        }
    }

    void LateUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Invoke("HideWeaponCollider", 1);
        }
    }

    void HideWeaponCollider()
    {
        TargetWeapon.SetActive(false);
    }

}
