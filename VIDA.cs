using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VIDA : MonoBehaviour
{
    [SerializeField] private Slider vida;
    [SerializeField] private Text numero;
    [SerializeField] private GameObject morte;
    [SerializeField] private GameObject vermelho;
    [SerializeField] private GameObject verde;
    [SerializeField] private int menos = 20;
    [SerializeField] private int mais = 10;
    [SerializeField] private Slider Escuro;
    [SerializeField] private Text txtescuro;
    [SerializeField] private Gradient va;
    [SerializeField] private GameObject HUD;
    [SerializeField] private AudioSource danos;
    [SerializeField] private GameObject ja;
    private void Awake()
    {
        morte.SetActive(false);
        verde.SetActive(false);
        vermelho.SetActive(false);
        danos.enabled = false;
    }
   



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("luz"))
        {
            //vida.value--;
            verde.SetActive(false);

           
            
            /*if (vida.value == 0)
            {
                Time.timeScale = 0f;
                morte.SetActive(true);
                
            */

            if (vida.value == 5)
            {
                
                vermelho.SetActive(true);
            }

            if (vida.value == 99)
            {
                
                //vida.value = menos--;
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            vida.value++;
            verde.SetActive(true);
            mais++;

            if (vida.value == 100)
            {
                verde.SetActive(false);
                vermelho.SetActive(false);
            }
           
        }

        numero.text = vida.value.ToString();
        txtescuro.text = Escuro.value.ToString();

        float Vectordis = Vector3.Distance(transform.position, ja.transform.position);

        if (Vectordis < 5)
        {
            danos.enabled = false;
            Debug.Log("foi");
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("luz")){
           for (int a = 1; a < menos; a++)
            {
                Escuro.value--;

                danos.loop =
               
                danos.enabled = true;

                if (Escuro.value == 0)
                {
                    vida.value--;

                    if (vida.value == 0)
                    {
                        morte.SetActive(true);
                        Time.timeScale = 0f;
                        Cursor.visible = true;
                        HUD.SetActive(false);

                      
                    }

                }
            }
        }
    }

    

    public void reinicia()
    {
        Application.LoadLevel(Application.loadedLevel);
        Time.timeScale = 1f;
        
    }

    private void OnDestroy(Collision olh)
    {
        if (olh.gameObject.CompareTag("luz"))
        {

        }
    }
}
