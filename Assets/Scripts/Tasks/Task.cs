using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Task : MonoBehaviour
{
    public string task;
    public bool isDone;
    private Toggle toggle;

    private void Awake()
    {
        isDone = false;
        toggle = GetComponent<Toggle>();
        toggle.text = task;
    }

    void SetTask(string newTask)
    {
        task = newTask;
    }
}
