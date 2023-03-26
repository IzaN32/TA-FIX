/*
 * Desc     : Membuat fungsi untuk melakukan simulasi switch/on-off
 * Author   : Rickman Roedavan
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hardcode_Switch : MonoBehaviour
{
    [Header("Main Settings")]
    bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isOn)
        {
            if (Input.GetKeyDown("kode keyboard"))
            {
                isOn = true;
                //ketik event di sini
            }
        }
        else
        {
            if (Input.GetKeyDown("kode keyboard"))
            {
                isOn = false;
                //ketik event di sini
            }
        }
    }
}
