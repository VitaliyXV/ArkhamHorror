using UnityEngine;
using System.Collections.Generic;
using System;

namespace ArkhamHorror.Tools
{
    public static class JsonHelper
    {
        public static T FromJson<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public static List<T> FromJsonToList<T>(string json)
        {
            var data = "{\"Items\":" + json + "}";
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(data);
            return wrapper.Items;
        }

        public static string FromListToJson<T>(List<T> array)
        {
            var wrapper = new Wrapper<T> {Items = array};
            return JsonUtility.ToJson(wrapper);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public List<T> Items;
        }
    }
}