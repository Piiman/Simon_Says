using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Btn_ingresar : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("simon");
    }
}
