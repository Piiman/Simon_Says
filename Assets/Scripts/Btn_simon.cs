using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Btn_simon : MonoBehaviour
{
    public AudioClip press,fail;
    public int col, XMin, XMax, YMin, YMax;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (Eventos.vivo == true && Eventos.mostrando == false)
        {
            if (Eventos.historial[Eventos.indice] == col)
            {
                Eventos.indice++;
                audio.PlayOneShot(press);
            }
            else
            {
                audio.PlayOneShot(fail);
                Eventos.vivo = false;
                Eventos.tiempo_final = Eventos.timer;
            }
        }
        else if (Eventos.vivo == false)
        {
            SceneManager.LoadScene("simon");
        }
    }

    
}
