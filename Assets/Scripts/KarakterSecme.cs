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

    public static int currentIndex = 0; //varsayýlan seçenek
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
            karakter.SetActive(false); //bir önceki karakteri kapatýr (zorluk çýkarmasýn diye)
        }
        karakterler[currentIndex].SetActive(true);

        karakterAdi.text = karakterler[currentIndex].name; //4.karakteri geçtiysen ilk karaktere geri dön
    }

    public void sagButonTiklandiginda()
    {
        currentIndex=(currentIndex+1)%karakterler.Count;

        KarakterGorunumuGuncelle();
    }

    public void solButonTiklandiginda()
    {
        currentIndex--; // Ýndeksi bir azalt

        if (currentIndex < 0) // Negatif bir deðere düþtüyse
        {
            currentIndex = karakterler.Count - 1; // En son karaktere dön
        }

        KarakterGorunumuGuncelle(); // Karakter görünümünü güncelle
    }


    void secButonunaTiklandiginda()
    {
        SceneManager.LoadScene(1);
        //oyun içi ayarlarý veya oyuncu tercihlerini kaydetmek için kullanýlýr
        PlayerPrefs.SetInt("SelectedCharacterIndex", currentIndex);
        PlayerPrefs.Save();
    }
}
