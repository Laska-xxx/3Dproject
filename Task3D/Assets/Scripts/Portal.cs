using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform place;
    [SerializeField] GameObject text;
    [SerializeField] GameObject money;
    bool check = false;
    PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        if(Input.anyKey && check) text.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = place.transform.position;
            Invoke("cheking", 1);
            text.SetActive(true);
            money.SetActive(true);
        }
    }
    void cheking()
    {
        check = true;
    }
}
