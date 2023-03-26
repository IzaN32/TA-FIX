/*
 * Desc     : Membuat fungsi untuk mendeteksi input
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inspector_Input : MonoBehaviour
{


    [Header("Main Settings")]
    public KeyCode TargetKey;
    public UnityEvent InputEvent;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(TargetKey))
        {
            InputEvent.Invoke();
        }
    }
}
