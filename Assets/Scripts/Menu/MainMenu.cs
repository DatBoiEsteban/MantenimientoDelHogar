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
    public GameObject BDErrorMessage;
    private bool isConnected;    
    public levelC transicion;
    public Animator animator;
    private void Update()
    {

        if (!isConnected && BDConnection.Instance.session.status == "200")
        {
            isConnected = true;
            transicion.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (BDConnection.Instance.session.status == "404" && BDErrorMessage.GetComponent<Text>().text != BDConnection.Instance.session.message)
        {
            BDErrorMessage.GetComponent<Text>().text = BDConnection.Instance.session.message;
            animator.SetTrigger("BDError");
        }
        Debug.Log(BDConnection.Instance.session.status);
    }
    public void PlayGame() 
    {
        Usuario = UsuarioInputField.GetComponent<InputField>().text;        
        Contra = ContraInputField.GetComponent<InputField>().text;
        

        animator.SetTrigger("removePassword");       
        animator.SetTrigger("removeUser");
        animator.SetTrigger("removeBoth");
        animator.SetTrigger("removeBDErrorMessage");
        animator.SetTrigger("ToInitial");

        if (Usuario !="" && Contra != "")
        {   
            BDConnection.Instance.Login(Usuario, Contra);                                       
            
        }
        else if (Usuario=="" && Contra != "")
        {
            animator.SetTrigger("userTrigger");
        }
        else if(Usuario != "" && Contra == "")
        {
            animator.SetTrigger("passwordTrigger");
            //Debug.Log("Me cago en Segura");
        }
        else if (Usuario == "" && Contra == "")
        {

            animator.SetTrigger("UserPasswordTrigger");
        }
        UsuarioInputField.GetComponent<InputField>().text = "";
        ContraInputField.GetComponent<InputField>().text = "";

    }
}
