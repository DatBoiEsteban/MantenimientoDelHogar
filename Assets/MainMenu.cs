using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static BDConnection;
public class MainMenu : MonoBehaviour
{
    public string Usuario = "";
    public string Contra= "";

    public GameObject UsuarioInputField;
    public GameObject ContraInputField;


    public void PlayGame() 
    {
        Usuario = UsuarioInputField.GetComponent<InputField>().text;        
        Contra = ContraInputField.GetComponent<InputField>().text; 
        if (Usuario !="" && Contra != "")
        {
            BDConnection.Instance.Login(Usuario, Contra);
        }
             
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
