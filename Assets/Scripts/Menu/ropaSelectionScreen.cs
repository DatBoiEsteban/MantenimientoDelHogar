using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ropaSelectionScreen : MonoBehaviour
{
    public Animator animator;
    public levelC transicion;
    public void mostrarMensajeNY()
    {
        animator.SetTrigger("Appear");
        animator.SetTrigger("Disappear");
        animator.SetTrigger("hereWeGoAgain");
       
    }
    public void BackToGameSelection()
    {
        transicion.FadeToLevel(1);
    }
}
