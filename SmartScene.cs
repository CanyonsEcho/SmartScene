using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Canyons.SmartScene
{
    public static class SmartScene
    {
        private static Dictionary<string, object> sceneData = new Dictionary<string, object>();

        public static void ChangeSceneWithData(string sceneName, params object[] data)
        {
            sceneData.Clear();

            for (int i = 0; i < data.Length; i++)
            {
                sceneData[$"data{i}"] = data[i];
            }

            SceneManager.LoadScene(sceneName);
        }

        public static T GetDataFromSceneChange<T>(int index)
        {
            string key = $"data{index}";
            if (sceneData.TryGetValue(key, out object value))
            {
                return (T)value;
            }

            return default;
        }
    }
}
