using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string Usuario = "";
    public string Contra= "";

    public GameObject UsuarioInputField;
    public GameObject ContraInputField;
    private bool isConnected;
    public levelC transicion;
    private void Update()
    {
        Debug.Log(BDConnection.Instance.session.status);
        if (!isConnected && BDConnection.Instance.session.status == "200")
        {
            isConnected = true;
            transicion.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
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
