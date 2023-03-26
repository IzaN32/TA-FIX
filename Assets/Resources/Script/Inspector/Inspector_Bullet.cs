/*
 * Desc     : Membuat fungsi untuk pergerakan bullet
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Bullet : MonoBehaviour
{
    [Header("Main Settings")]
    public GameObject TargetBullet;
    public float Speed;
    public float DestroyTime;

    // Start is called before the first frame update
    void Start()
    {
        //memanggil fungsi menurut waktu
        Invoke("DestroyBullet", DestroyTime);
    }

    void DestroyBullet()
    {
        //menghancurkan objek
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //menggerakan objek ke depan
        TargetBullet.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
