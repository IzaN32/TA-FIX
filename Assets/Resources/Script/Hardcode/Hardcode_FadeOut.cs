/*
 * Desc     : Membuat fungsi fade out menggunakan komponen Image
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hardcode_FadeOut : MonoBehaviour
{

    Image TargetImage;
    float FadeSpeed = 1;
    float Delay = 3;
    bool StartFadeOut = false;

    void Awake()
    {
        //Mendapatkan komponen Image secara otomatis. Catatan: Script ini harus dipasang di komponen Image
        TargetImage = GetComponent<Image>();

        //Membuat TargetImage sesuai dengan ukuran layar
        TargetImage.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        //Membuat TargetImage 'menghilang' dari canvas
        TargetImage.enabled = false;
        TargetImage.color = Color.clear;
    }

    void FadeOut()
    {
        //Membuat warna TargetImage pakai transisi Lerp dari transparan ke warna dasar gambar
        TargetImage.color = Color.Lerp(TargetImage.color, Color.black, FadeSpeed * Time.deltaTime);
    }
    // Start is called before the first frame update
    void Start()
    {
        //Memanggil fungsi SetTrue_StartFadeOut berdasarkan delay
        Invoke("SetTrue_StartFadeOut", Delay);
    }


    void SetTrue_StartFadeOut()
    {
        //Mengubah nilai StartFadeOut menjadi true
        StartFadeOut = true;
        //Membuat TargetImage 'muncul' dari canvas
        TargetImage.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Eksekusi fungsi FadeOut jika nilai StartFadeOut = true
        if (StartFadeOut)
        {
            FadeOut();
        }
    }
}
