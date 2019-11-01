using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BDConnection;
public class MainMenu : MonoBehaviour
{
    public string UsuarioInputField = "";
    public string ContraInputField = "";

    public GameObject username;
    public GameObject password;


    public void PlayGame() 
    {
        UsuarioInputField = username.GetComponent<InputField>().text;        
        ContraInputField = password.GetComponent<InputField>().text; 
        if (UsuarioInputField !="" && ContraInputField != "")
        {
            BDConnection.Instance.Login(UsuarioInputField, ContraInputField);
        }
             
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
