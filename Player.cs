using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private float movimento;
    [SerializeField] private int somar = 0;
    [SerializeField] private Text txt;
    [SerializeField] private float speed = 9f;
    [SerializeField] private GameObject IA;
    [SerializeField] private Slider custadevida;
   
    private int m = 5;
    void Update()
    {
       
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, movimento * Time.deltaTime));
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.Translate(new Vector3(0, 0, +speed * Time.deltaTime));
            }
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -movimento * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(movimento * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-movimento * Time.deltaTime, 0, 0));
        }
        
    }



    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("obj"))
        {
            Destroy(collision.gameObject);
            somar++;
            txt.text = somar.ToString();
        }

        
    }
}