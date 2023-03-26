/*
 * Desc     : Membuat fungsi untuk mematikan aplikasi/game
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_GameQuit : MonoBehaviour
{
    public void QuitGame()
    {
        //mematikan game saat dalam editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        //mematikan game setelah di build
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
