/*
 * Desc     : Membuat fungsi untuk instantiasi objek berdasarkan waktu
 * Author   : Rickman Roedavan
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inspector_InstantiateRepeat : MonoBehaviour
{

    [Header("Main Settings")]
    public GameObject TargetPrefab;
    public GameObject TargetPosition;
    public float Interval;

    public void StartInstantiate()
    {
        GameObject temp = GameObject.Instantiate(TargetPrefab, TargetPosition.transform.position, TargetPosition.transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("StartInstantiate", 1, Interval);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
