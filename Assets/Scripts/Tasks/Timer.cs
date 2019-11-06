using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    private float time;
    private float totalTime;
    private List<float> timeStamps = new List<float>();
    private bool running;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (running)
        {
            time += Time.deltaTime;
        }
    }

    public double getTime()
    {
        return time;
    }

    public double getTotalTime()
    {
        return totalTime;
    }

    public void resetTimer()
    {
        time = 0;
    }

    public void makeTimeStamp()
    {
        totalTime += time;
        timeStamps.Add(time);
        resetTimer();
    }

    public void startTimer()
    {
        running = true;
    }

    public void pauseTimer()
    {
        running = false;
    }

    public string formatTotal()
    {
        string hours = Mathf.Floor((totalTime % 216000) / 3600).ToString("00");
        string minutes = Mathf.Floor((totalTime % 3600) / 60).ToString("00");
        string seconds = (totalTime % 60).ToString("00");
        return hours + ":" + minutes + ":" + seconds + "." + (totalTime - (int)totalTime);
    }

    public float[] getTimestamps()
    {
        return timeStamps.ToArray();
    }
}
