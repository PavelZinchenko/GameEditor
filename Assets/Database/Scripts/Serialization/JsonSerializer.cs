using UnityEngine;

namespace GameDatabase.Serialization
{
    public interface IJsonSerializer
    {
        T FromJson<T>(string data);
        string ToJson<T>(T item);
    }

    public class UnityJsonSerializer : IJsonSerializer
    {
        public T FromJson<T>(string data)
        {
            return JsonUtility.FromJson<T>(data);
        }

        public string ToJson<T>(T item)
        {
            return JsonUtility.ToJson(item, true);
        }
    }
}
