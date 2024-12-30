using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    float hiz = 10f; //mevcut hýz

    public void hizAyarla(float newHiz)
    {
        hiz = newHiz; //yeni hýz
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hiz); //hýzý göster
        transform.Translate(Vector3.left * Time.deltaTime * hiz); //objeler hýzla orantýlý sola doðru hareket edecek
    }
}
