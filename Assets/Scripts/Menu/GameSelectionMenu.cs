using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameSelectionMenu : MonoBehaviour
{
    public levelC transicion;
    // Start is called before the first frame update
    public void MenuMantenimiento()
    {
        transicion.FadeToLevel(2);
    }
    public void MenuRopa()
    {
        transicion.FadeToLevel(3);
    }

}
