/*
 * Desc     : Membuat fungsi untuk instantiasi objek
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_Instantiate : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetPrefab;
    public GameObject TargetPosition;

    public void StartInstantiate()
    {
        GameObject temp = GameObject.Instantiate(TargetPrefab, TargetPosition.transform.position, TargetPosition.transform.rotation);
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
