using System;


namespace NetModels
{
    [Serializable]
    public class User
    {
        public string user_id;
        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}

