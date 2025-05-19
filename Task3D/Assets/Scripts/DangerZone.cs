using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    [SerializeField] int time;
    [SerializeField] GameObject box;
    [SerializeField] int height;
    
    bool check;
    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            check = true;
            StartCoroutine(Create());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) check = false;
    }
    IEnumerator Create()
    {
        while(check == true)
        {
            yield return new WaitForSeconds(time);
            Spawn();
        }
    }
    void Spawn()
    {
        Vector3 spawn = player.transform.position + new Vector3(0,height,0);
        Instantiate(box, spawn, Quaternion.identity);
    } 
}
