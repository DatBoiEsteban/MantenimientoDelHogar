using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HogarSelectionScreen : MonoBehaviour
{
    //public Animator animator;
    public levelC transicion;
    
    public void BackToGameSelection()
    {
        transicion.FadeToLevel(1);
    }
    public void goToCuadro()
    {
        transicion.FadeToLevel(4);
    }
    public void goToCochera()
    {
        //transicion.FadeToLevel(5);
    }
    public void goToFlorero()
    {
        //transicion.FadeToLevel(6);
    }
}
