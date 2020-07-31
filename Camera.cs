using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.Video;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private float rotacao = 0;
    [SerializeField] private float se = 5f;
    [SerializeField] private Text txt;
    [SerializeField] private Slider valor;
    [SerializeField] private Canvas configura;
    [SerializeField] private AudioSource som;
    [SerializeField] private Slider controle;
    [SerializeField] private Text numerodemouse;
    [SerializeField] private Canvas volta;
    [SerializeField] private Toggle ativerg;
    [SerializeField] private Canvas inventario;
    [SerializeField] private GameObject lixos;
    [SerializeField] private GameObject clicarlixo;
    [SerializeField] private Image deletarimg;
    [SerializeField] private Canvas avisar;
    [SerializeField] private Texture2D cursor;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject HUD;
    [SerializeField] private AudioSource asource;
    [SerializeField] private GameObject botaoconfigSom;
    [SerializeField] private GameObject retunr;

    [SerializeField] private Text t;
    [SerializeField] private int vida = 100;
    

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
       
        configura.enabled = false;
        inventario.enabled = false;
        clicarlixo.SetActive(false);
        avisar.enabled = false;
        PauseMenu.SetActive(false);
        asource.mute = false;
        
    }



    private void Update()
    {
        // camera mover 
        float mouseY = Input.GetAxis("Mouse Y") * se * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * se * Time.deltaTime;

        rotacao -= mouseY;
        rotacao = Mathf.Clamp(rotacao, -80f, 100f);
        transform.localRotation = Quaternion.Euler(rotacao, 0f, 0f);
        tr.Rotate(Vector3.up, mouseX);


        t.text = vida.ToString();



        cursormouse();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu)
            {
                Gamepause();
                Debug.Log("espace");
            }
            else
            {
                returno1();
            }

        }



        if (Input.GetKeyDown(KeyCode.I))
        {

            Time.timeScale = 0f;
            Cursor.visible = !Cursor.visible;
            inventario.enabled = !inventario.enabled;
        }
    }

   

    private void Gamepause ()
    {
        
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        hud();
        Cursor.visible = true;
    }

    public void returno1()
    {
        hud();
        HUD.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

   

    public void SomReturno()
    {
        if (retunr)
        {
            asource.Play();
        }
    }



    // hud 
    public void hud()
    {
        if (HUD)
        {
            HUD.SetActive(false);
        }
    }


    // cursor 
    public void cursormouse()
    {
        //Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Configuracao()
    {
        configura.enabled = true;
       
        
    }


    public void sairdojogo()
    {
        Application.Quit();
       
    }

    public void voltar()
    {
        volta.enabled = false;
       
    }

    //SOM de configuracao 
    public void volumer()
    {
        //audiomixer.SetFloat("volume", valor.value);
        txt.text = valor.value.ToString();
        //audiomixer.SetFloat("numero", numero);
       
    }

    public void mute()
    {
        som.mute = !som.mute;
        //toggler.enabled = som.mute;
       
    }

    // controle de mouse 
   public void controlemouse()
    {
        se = controle.value;
        numerodemouse.text = controle.value.ToString();   
    }

    // qualidade 
    public void ultra()
    {
        QualitySettings.SetQualityLevel(5,true);
     
    }

    public void alto()
    {
        QualitySettings.SetQualityLevel(3, true);
    }

    public void medio()
    {
        QualitySettings.SetQualityLevel(2,true);
    }

    public void baixo()
    {
        QualitySettings.SetQualityLevel(1, true);
    }
 
   

   public void lixo()
    {
        //clicarlixo.active = !clicarlixo.active;
        //clicarlixo.SetActive(true);
        if (clicarlixo)
        {
            clicarlixo.SetActive(true);

        } 
        else if (clicarlixo == false)
        {
            clicarlixo.SetActive(false);
        }
    }
 
    public void aviso()
    {
        avisar.enabled = true;
    }

    public void Sim()
    {
        if (this.lixos)
        {
            Destroy(this.deletarimg);
            Destroy(this.lixos);
            avisar.enabled = false;
        }
    }

    public void Nao()
    {
        avisar.enabled = false;
    }

    public void configSom()
    {
       if (botaoconfigSom == true)
        {
            asource.Play();
        }
    }
    




}
