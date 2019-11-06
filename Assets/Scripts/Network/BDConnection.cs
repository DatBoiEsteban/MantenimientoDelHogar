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
    public Session session = null;
    private int stageId;

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
        Match match2 = Regex.Match(pUsername, "^[0-9]{9,9}");
        int usernameType = -1;

        if (match.Success)
        {
            usernameType = 1;
        }
        else if (match2.Success)
        {
            usernameType = 0;
        }
        if (usernameType != -1)
        {
            RequestHelper options = GetRequestHelper("/app_user/auth", new Login { password = pPassword, username = pUsername, username_type = usernameType });
            RestClient.Post(options)
                .Then(res =>
                {
                    ResponseMessage<Session> Answer = JsonUtility.FromJson<ResponseMessage<Session>>(res.Text);
                    session = Answer.response;

                })
                .Catch(err => session = null);
        }
        
    }

    public void setStageId(int id)
    {
        stageId = id;
    }

    public void SendTime()
    {
        RequestHelper options = GetRequestHelper("/scores/create", new Timestamps {idUser = session.user.user_id, idStage = stageId, times = Timer.Instance.getTimestamps() });
        RestClient.Post(options);
    }
}
