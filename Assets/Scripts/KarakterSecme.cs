using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class KarakterSecme : MonoBehaviour
{
    public List<GameObject> karakterler = new List<GameObject>();
    public TextMeshProUGUI karakterAdi;
    public Button selectButton;

    public static int currentIndex = 0; //varsay�lan se�enek
    // Start is called before the first frame update
    void Start()
    {
        KarakterGorunumuGuncelle();
        selectButton.onClick.AddListener(secButonunaTiklandiginda);
    }

    // Update is called once per frame
    void KarakterGorunumuGuncelle()
    {
        foreach (var karakter in karakterler) 
        { 
            karakter.SetActive(false); //bir �nceki karakteri kapat�r (zorluk ��karmas�n diye)
        }
        karakterler[currentIndex].SetActive(true);

        karakterAdi.text = karakterler[currentIndex].name; //4.karakteri ge�tiysen ilk karaktere geri d�n
    }

    public void sagButonTiklandiginda()
    {
        currentIndex=(currentIndex+1)%karakterler.Count;

        KarakterGorunumuGuncelle();
    }

    public void solButonTiklandiginda()
    {
        currentIndex--; // �ndeksi bir azalt

        if (currentIndex < 0) // Negatif bir de�ere d��t�yse
        {
            currentIndex = karakterler.Count - 1; // En son karaktere d�n
        }

        KarakterGorunumuGuncelle(); // Karakter g�r�n�m�n� g�ncelle
    }


    void secButonunaTiklandiginda()
    {
        SceneManager.LoadScene(1);
        //oyun i�i ayarlar� veya oyuncu tercihlerini kaydetmek i�in kullan�l�r
        PlayerPrefs.SetInt("SelectedCharacterIndex", currentIndex);
        PlayerPrefs.Save();
    }
}
