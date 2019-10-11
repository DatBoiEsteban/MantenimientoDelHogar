using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksManager : MonoBehaviour
{

    public List<GameObject> Objectives;
    public List<string> tasks;
    public List<GameObject> toggles = new List<GameObject>();
    private int index = 0;
    public GameObject panel;
    public GameObject prefab;

    private void Start()
    {
        Objectives[index].GetComponent<placeable>().canPlace = true;

        CreateTasks();
    }

    private void Update()
    {
        if (index < Objectives.Count)
        {
            Objectives[index].GetComponent<placeable>().canPlace = true;
            if (Objectives[index].layer != 10)
            {
                toggles[index].GetComponent<Toggle>().isOn = true;
                Objectives[index].GetComponent<placeable>().canPlace = false;
                index += 1;                    
            }
        }
        else
        {
            //TODO: terminar partida
        }
    }

    private void CreateTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            GameObject a = Instantiate(prefab, panel.transform);
            //a.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            a.GetComponentInChildren<Text>().text = tasks[i];
            toggles.Add(a);
        }
    }
}
