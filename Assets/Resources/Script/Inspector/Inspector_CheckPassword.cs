/*
 * Desc     : Membuat fungsi untuk pengecekan input pada teks field
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Inspector_CheckPassword : MonoBehaviour
{

    [Header("Main Settings")]
    public InputField TextInput;
    public string CorrectAnswer;

    [Header("Events Settings")]
    public UnityEvent TrueAnswer;
    public UnityEvent FalseAnswer;

    public void CheckAnswer()
    {
        if (TextInput.text.ToUpper() == CorrectAnswer.ToUpper())
        {
            TrueAnswer.Invoke();
        }
        else 
        {
            FalseAnswer.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            CheckAnswer();
        }
    }
}
