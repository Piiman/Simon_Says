using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eventos : MonoBehaviour
{
    public static List<int> historial;
    public static int indice,puntos;
    public static bool vivo, mostrando;
    public static float timer, tiempo_final;

    
    public Text imprimir,marcador,tiempo;
    public AudioClip go,press,pass;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        puntos = 0;
        indice = 0;
        vivo = true;
        historial = new List<int>();
        StartCoroutine(Colores());
    }

    // Update is called once per frame
    void Update()
    {
        if(historial.Count == indice)
        {
            audio.PlayOneShot(pass);
            puntos++;
            StartCoroutine(Colores());
        }
        if (!vivo)
        {
            imprimir.text = "Fin del juego \nPresiona cualquier boton para reiniciar";
            marcador.text = $"puntuacion final: {puntos}";
            tiempo.text = $"Tiempo: {tiempo_final}";
        } else
        {
            marcador.text = $"puntuacion: {puntos}";
            tiempo.text = $"Tiempo: {timer}";
        }
        timer += Time.deltaTime;
    }

    public IEnumerator Colores()
    {
        mostrando = true;
        historial.Add(UnityEngine.Random.Range(0,4));
        foreach(int item in historial)
        {
            imprimir.text = "";
            yield return new WaitForSeconds(1);
            switch (item)
            {
                case 0:
                    imprimir.text = "rojo";
                    audio.PlayOneShot(press);
                    break;
                case 1:
                    imprimir.text = "azul";
                    audio.PlayOneShot(press);
                    break;
                case 2:
                    imprimir.text = "verde";
                    audio.PlayOneShot(press);
                    break;
                case 3:
                    imprimir.text = "amarillo";
                    audio.PlayOneShot(press);
                    break;
            }
            yield return new WaitForSeconds(1);          
        }
        indice = 0;
        mostrando = false;
        audio.PlayOneShot(go);
        imprimir.text = "GO";
    }
}
