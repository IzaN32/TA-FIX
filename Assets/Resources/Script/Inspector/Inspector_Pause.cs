/*
 * Desc     : Membuat fungsi untuk melakukan pause
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inspector_Pause : MonoBehaviour
{

    [Header("Main Settings")]
    public UnityEvent PauseEvent;
    public UnityEvent PlayEvent;

    public void Pause()
    {
        //membuat time game berhenti
        Time.timeScale = 0;
        PauseEvent.Invoke();
    }

    public void Play()
    {
        //membuat time game kembali normal
        Time.timeScale = 1;
        PlayEvent.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

