/*
 * Desc     : Membuat fungsi untuk membuat timer sederhana
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inspector_Timer : MonoBehaviour
{
    [Header("Main Settings")]
    public float DataTimer;
    public Text TextTimer;

    [Header("Condition")]
    public UnityEvent TimerFinihEvent;
    bool isExecuted = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartTimer", 1, 1);
    }

    void StartTimer()
    {
        if (DataTimer > 0)
        {
            DataTimer--;
            TextTimer.text = DataTimer.ToString();
        }
        if (DataTimer == 0)
        {
            TimerFinihEvent.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
