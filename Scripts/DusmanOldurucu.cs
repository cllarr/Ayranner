using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DusmanOldurucu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dusman"))
        {
            Destroy(collision.gameObject); //optimizasyon i�in
        }
    }
}