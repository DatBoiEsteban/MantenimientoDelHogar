using System;

namespace NetModels
{
    public class Timestamps
    {
        public string idUser;
        public int idStage;
        public float[] times;

        public override string ToString()
        {
            return UnityEngine.JsonUtility.ToJson(this, true);
        }
    }
}