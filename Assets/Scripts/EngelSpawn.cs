using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using Debug = UnityEngine.Debug;

public class EngelSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] engelPrefab; //engel listesi
    [SerializeField] TMP_Text scoreText; //skor yazýsý
    float baslangicHizi = 10f;
    float maxHiz = 35f;
    float hizArtis = 1f;
    float zamanGecti = 0f;
    int skor = 0;
    float skorArtisOrani = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Engelspawn());
        StartCoroutine(Gecikmeli());
    }


    IEnumerator Engelspawn()
    {
        while (true)
        {
            float randomGecikme = Random.Range(0.7f, 2.2f);//0.7 saniye
            yield return new WaitForSeconds(randomGecikme); //bu kadar süre bekle

            int i = Random.Range(0, engelPrefab.Length); //random engel (engelPrefab.Length ise )
            Vector3 spawnPosition = transform.position;//spawn manager nereye koyarsak orada spawnalacak

            if (i == 1 || i == 2)
            {
                spawnPosition.y += 2;//üstten engel 1cm olacak 
            }
            GameObject engel = Instantiate(engelPrefab[i], spawnPosition, Quaternion.identity);
            Engel engelScript = engel.GetComponent<Engel>(); //Engel.cs scriptini tanýmladýk

            if (engelScript != null)
            {
                engelScript.hizAyarla(baslangicHizi);
            }
        }
    }


    void artisHizi()
    {
        baslangicHizi += hizArtis;
        if (baslangicHizi > maxHiz)
        {
            baslangicHizi = maxHiz;
        }
        skorArtisOrani = baslangicHizi / 10f; //skora göre hýz artacak
    }

    IEnumerator Gecikmeli()
    {
        while (true)
        {
            skor += 1;
            //Debug.Log(skor); //unity engine debugý kullanýyoruz
            scoreText.text = "Skor= " + skor.ToString();
            yield return new WaitForSeconds(1f / skorArtisOrani);
        }
    }


    private void FixedUpdate()
    {
        zamanGecti += Time.deltaTime; //Geçen süreyi ekliyor
        if (zamanGecti >= 5f) //hýz 5 saniyede bir artacak
        {
            zamanGecti = 0;
            artisHizi();
        }

    }

}
