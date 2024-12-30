using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;

public class OyuncuHareket : MonoBehaviour
{
    float ziplamaGucu = 8f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform yerTespit;
    [SerializeField] private LayerMask yerLayer;

    [SerializeField] GameObject Panel;
    [SerializeField] GameObject RestartTusu;
    [SerializeField] AudioSource ArkaplanSesi;
    [SerializeField] AudioSource dieSource;
    GameObject Arkaplan;
    // Start is called before the first frame update
    void Start()
    {
        Panel = GameObject.Find("Panel");
        RestartTusu = GameObject.Find("RestartTusu");
        Arkaplan = GameObject.Find("Arkaplan");
        ArkaplanSesi = Arkaplan.GetComponent<AudioSource>();

        Panel.SetActive(false);
        RestartTusu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && YerdeMi())
        {
            rb.velocity = new Vector2(rb.velocity.x, ziplamaGucu); //z plad ysam y'ye ziplamaGucu uygula
        }
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    bool YerdeMi() //yer tespiti e er yere yak nl k 0.2f veya daha azsa True d n yor
    {
        return Physics2D.OverlapCircle(yerTespit.position, 0.2f, yerLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dusman"))
        {
            dieSource.Play();
            ArkaplanSesi.Stop();
            Panel.SetActive(true);
            RestartTusu.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
