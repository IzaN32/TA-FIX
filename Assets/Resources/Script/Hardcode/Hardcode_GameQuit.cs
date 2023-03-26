/*
 * Desc     : Membuat fungsi untuk mematikan aplikasi/game
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hardcode_GameQuit : MonoBehaviour
{
    Button TargetButton;

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
        TargetButton = GetComponent<Button>();
        TargetButton.onClick.AddListener(QuitGame);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
