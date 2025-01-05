using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engel : MonoBehaviour
{
    float hiz = 10f; // mevcut hız

    public void hizAyarla(float newHiz)
    {
        try
        {
            // Hız negatif veya çok büyük bir değer olursa uyarı loglanabilir.
            if (newHiz < 0 || newHiz > 100)
                throw new System.ArgumentOutOfRangeException("newHiz", "Hız 0 ile 100 arasında olmalıdır!");

            hiz = newHiz; // yeni hız
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            Debug.LogError($"Hatalı hız değeri: {e.Message}");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Hız ayarlanırken beklenmeyen bir hata oluştu: {e.Message}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Debug.Log(hiz); // hızı göster
            if (hiz == 0)
                throw new System.Exception("Hız sıfır olamaz, obje hareket etmeyecek!");

            // objeler hızla orantılı sola doğru hareket edecek
            transform.Translate(Vector3.left * Time.deltaTime * hiz);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Update sırasında hata oluştu: {e.Message}");
        }
    }
}
