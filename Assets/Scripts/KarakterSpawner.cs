using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KarakterSpawner : MonoBehaviour
{
    public GameObject[] karakterler;
    int index = 0;
    void Start()
    {
        index = KarakterSecme.currentIndex;
        Debug.Log("Index : " + index);

        int selected = index;

        if (selected >= 0 && selected < karakterler.Length)
        {
            GameObject selectedCharacterPrefab = karakterler[selected]; //se�ilen karakterin indexi at�l�yor
            Instantiate(selectedCharacterPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Index de�eri hatal�");
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }
}
