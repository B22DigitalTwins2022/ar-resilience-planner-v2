using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShapeReality.ARResiliencePlanner
{
    /// <summary>The entry point of the entire app. Any initialisation is done here</summary>
    public sealed class App : MonoBehaviour
    {
        public void Awake()
        {
            //Application.targetFrameRate = 60;

            InitializeScene(Constants.Scenes.SCENENAME_ENVIRONMENT);
        }

        private void InitializeScene(string sceneName)
        {
#if UNITY_EDITOR
            if (SceneManager.GetSceneByName(sceneName) != null) { return; };
#endif
            AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            op.completed += (AsyncOperation result) =>
            {
                print("SceneEditor initialized");
            };
        }
    }
}