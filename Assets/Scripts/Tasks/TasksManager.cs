using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TasksManager : MonoBehaviour
{

    public List<GameObject> Objectives;
    public List<string> tasks;
    private List<GameObject> toggles = new List<GameObject>();
    private int index = 0;
    public GameObject panel;
    public GameObject prefab;

    private void Start()
    {
        Objectives[index].GetComponent<placeable>().canPlace = true;
        Objectives.ForEach(delegate (GameObject objective)
        {
            objective.SetActive(false);
        });
        setCurrentActive();
        CreateTasks();
    }

    private void Update()
    {
        if (index < Objectives.Count)
        {
            if (Objectives[index].layer != 10)
            {
                toggles[index].GetComponent<Toggle>().isOn = true;
                Objectives[index].GetComponent<placeable>().canPlace = false;
                index += 1;
                if (index < Objectives.Count)
                {
                    setCurrentActive();
                }
                
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
            Vector2 ab = a.GetComponent<RectTransform>().anchoredPosition;
            a.GetComponent<RectTransform>().anchoredPosition = new Vector2(ab.x, -15 - 20 * i);
            a.GetComponentInChildren<Text>().text = tasks[i];
            toggles.Add(a);
        }
    }

    private void setCurrentActive()
    {
        Objectives[index].SetActive(true);
    }
}
