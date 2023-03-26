/*
 * Desc     : Membuat fungsi untuk pergerakan third person
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_LookAt : MonoBehaviour
{

    [Header("Main Settings")]
    public CharacterController TargetPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = TargetPlayer.transform.position;
        temp.y = transform.position.y;
        transform.LookAt(temp);        
    }
}
