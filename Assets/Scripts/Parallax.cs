using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    Material _mat;
    float distance;
    float timeSinceLastIncrease = 0f;

    [SerializeField] float baslangicHizi;
    [SerializeField] float hizArtisOrani = 0.01f;
    [SerializeField] float maxHiz;


    // Start is called before the first frame update
    void Start()
    {
        _mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //hýzý yavaþça artýr
        timeSinceLastIncrease = Time.deltaTime;
        if (timeSinceLastIncrease >= 10f)
        {
            baslangicHizi += hizArtisOrani;
            baslangicHizi = Mathf.Min(baslangicHizi, maxHiz);
        }

        //Arka planý hareketlendir
        distance += Time.deltaTime * baslangicHizi;
        _mat.SetTextureOffset("_MainTex", new Vector2(distance, 0));
    }
}
