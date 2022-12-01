using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float timeDelay;
    private PlayerStates player;
    private DateTime lastCounter;


    private void OnTriggerEnter2D(Collider2D info)
    {
        //ƒелаем проверку сколько времени идет контакт
        if ((DateTime.Now - lastCounter).TotalSeconds < 0.1f)
            return;
        lastCounter = DateTime.Now;
        player = info.GetComponent<PlayerStates>();
        if (player != null)
        {
            player.ChangeHp(-damage);
        }
    }

    private void OnTriggerExit2D(Collider2D info)
    {
        if (player == info.GetComponent<PlayerStates>())
            player = null;
    }

    private void Update()
    {
        if (player != null && (DateTime.Now - lastCounter).TotalSeconds > timeDelay)
        {
            player.ChangeHp(-damage);
            lastCounter= DateTime.Now;
        }
    }
}
