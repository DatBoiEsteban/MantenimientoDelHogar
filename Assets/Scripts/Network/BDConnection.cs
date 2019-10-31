using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDConnection : MonoBehaviour
{
    public static BDConnection Instance { get; private set; }
    private const string API_URL = "https://brain-boost-backend.herokuapp.com/api/app_user/auth/";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }
}
