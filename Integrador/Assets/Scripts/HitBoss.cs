using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Personaje3D>().HP_min -= damage;
        }
    }
}
