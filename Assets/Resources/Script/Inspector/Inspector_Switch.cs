/*
 * Desc     : Membuat fungsi untuk melakukan simulasi switch/on-off
 * Author   : Rickman Roedavan
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Inspector_Switch : MonoBehaviour
{
    [Header("Main Settings")]
    public KeyCode KeyOn;
    public UnityEvent EventOn;
    public KeyCode KeyOff;
    public UnityEvent EventOff;
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
            if (Input.GetKeyDown(KeyOn))
            {
                isOn = true;
                EventOn.Invoke();
            }
        } else
        {
            if (Input.GetKeyDown(KeyOff))
            {
                isOn = false;
                EventOff.Invoke();
            }
        }
    }
}
