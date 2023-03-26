/*
 * Desc     : Menampilkan angka pada text berdasarkan nilai pada script lain
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inspector_FloatText : MonoBehaviour
{

    [Header("Main Settings")]
    public Inspector_Float FloatValue;
    public Text FloatText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FloatText.text = FloatValue.DataFloat.ToString();
    }
}
