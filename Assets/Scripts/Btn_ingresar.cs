using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn_ingresar : MonoBehaviour
{

    string usuario, pwd;
    public InputField user, pass;
    public Text warn;

    private void Start()
    {
        StartCoroutine(GetRequest("https://raw.githubusercontent.com/Chezzar/PruebaUnityLogin/master/LoginUser"));
    }

    private void OnMouseDown()
    {
        if(user.text.Equals("") || pass.text.Equals(""))
        {
            warn.text = "Ingresa un usuario y/o contraseña";
        }
        else
        {
            if(user.text.Equals(usuario) && pass.text.Equals(pwd))
            {
                SceneManager.LoadScene("simon");
            }
            else
            {
                warn.text = "Usuario y/o contraseña incorrectos";
            }
        }
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            yield return webRequest.SendWebRequest();

            string[] paginas = uri.Split('/');
            int pagina = paginas.Length - 1;

            if (webRequest.isNetworkError)
            {
                Debug.Log(paginas[pagina] + ": Error: " + webRequest.error);
            }
            else
            {
                string[] temp = webRequest.downloadHandler.text.Split('"');
                usuario = temp[3];
                pwd = temp[7];
            }
        }
    }
}
