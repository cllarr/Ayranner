using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    float hiz = 10f; //mevcut h�z

    public void hizAyarla(float newHiz)
    {
        hiz = newHiz; //yeni h�z
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hiz); //h�z� g�ster
        transform.Translate(Vector3.left * Time.deltaTime * hiz); //objeler h�zla orant�l� sola do�ru hareket edecek
    }
}
