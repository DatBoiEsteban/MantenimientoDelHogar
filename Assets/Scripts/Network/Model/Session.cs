using System;


namespace NetModels
{
    [Serializable]
    public class Session : Response
    {
        public string token;
        public User user;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}