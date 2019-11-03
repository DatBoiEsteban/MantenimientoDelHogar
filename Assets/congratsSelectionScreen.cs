using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class congratsSelectionScreen : MonoBehaviour
{
    public levelC transicion;
    public void goToSelecion()
    {
        transicion.FadeToLevel(1);
    }
    public void CloseApp()
    {
        Application.Quit();
    }
}
