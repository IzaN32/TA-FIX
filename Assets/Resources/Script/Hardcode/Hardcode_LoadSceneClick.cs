/*
 * Desc     : Membuat fungsi perpindahan antar scene menggunakan event/click
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hardcode_LoadSceneClick : MonoBehaviour
{

    string TargetScene = "GameA04-GamePlay";
    Button TargetButton;

    public void LoadScene()
    {
        //Melakukan perpindahan antar scene. Catatan: Scene yang dipanggil sudah didaftarkan di Build Setting
        SceneManager.LoadScene(TargetScene);
    }

    // Start is called before the first frame update
    void Start()
    {
        TargetButton = GetComponent<Button>();
        TargetButton.onClick.AddListener(LoadScene);
    }

    // Update is called once per frame
    void Update()
    {

    }
}

