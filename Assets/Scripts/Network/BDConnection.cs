using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using NetModels;
using UnityEditor;
using System.Text.RegularExpressions;


public class BDConnection : MonoBehaviour
{
    public static BDConnection Instance { get; private set; }
    private const string API_URL = "https://brain-boost-backend.herokuapp.com/api";
    private Session session;

    private void LogMessage(string title, string message)
    {
#if UNITY_EDITOR
        EditorUtility.DisplayDialog(title, message, "Ok");
#else
		Debug.Log(message);
#endif
    }

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

    public RequestHelper GetRequestHelper(string Path, object pBody)
    {
        return new RequestHelper
        {
            Uri = API_URL + Path,
            Params = new Dictionary<string, string> {
                { "Content-Type", "application/json" }
            },
            Body = pBody
        };
    }

    public void Login(string pUsername, string pPassword)
    {
        Match match = Regex.Match(pUsername, "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$");
        int usernameType = 0;
        if (match.Success)
        {
            usernameType = 1;
        }
        RequestHelper options = GetRequestHelper("/app_user/auth", new Login { password = pPassword, username = pUsername, username_type = usernameType });
        RestClient.Post(options)
            .Then(res =>
            {
                ResponseMessage<Session> b = JsonUtility.FromJson<ResponseMessage<Session>>(res.Text);
                if (b.response.status != "404")
                {
                    session = b.response;
                }
            })
            .Catch(err => session = null);
    }
}
