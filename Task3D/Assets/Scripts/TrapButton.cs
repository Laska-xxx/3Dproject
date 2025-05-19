using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapButton : MonoBehaviour
{
    [SerializeField] Collider obj;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) obj.enabled = false;
    }
}
