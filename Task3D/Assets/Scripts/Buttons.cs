using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] bool bool1;
    [SerializeField] bool bool2;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) obj.SetActive(bool1);
    }
    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player")) obj.SetActive(bool2);
    }
}
