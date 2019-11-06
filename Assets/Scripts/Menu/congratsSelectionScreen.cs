using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class congratsSelectionScreen : MonoBehaviour
{
    public levelC transicion;
    public GameObject timeText;

    private void Start()
    {
        timeText.GetComponent<Text>().text = "Tiempo: "+ Timer.Instance.formatTotal();
    }

    public void goToSelecion()
    {
        transicion.FadeToLevel(1);
    }

    public void CloseApp()
    {
        Application.Quit();
    }
}
