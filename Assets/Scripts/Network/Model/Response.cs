using System;

namespace NetModels
{
    [Serializable]
    public class Response
    {
        public string status;
        public string message;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }

    [Serializable]
    public class ResponseMessage<T>
    {
        public T response;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}