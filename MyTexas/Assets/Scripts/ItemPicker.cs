using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{
    [SerializeField] private float healValue;
    private void OnTriggerEnter2D(Collider2D info)
    {
        info.GetComponent<PlayerStates>().ChangeHp(healValue);
        Destroy(gameObject);
    }
}

