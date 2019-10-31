using System;

namespace NetModels
{
    [Serializable]
    public class Login
    {
        public string username;
        public string password;
        public int username_type;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}