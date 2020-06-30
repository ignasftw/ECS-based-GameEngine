using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECSEngine
{
    public class SceneManager
    {
        //DECLARE an empty Dictionary of scenes which will be used for switching scenes, call it '_scenes'
        private Dictionary<string, Scene.Scene> _scenes = new Dictionary<string, Scene.Scene>();
        //DECLARE a Scene which will set the current scene, call it '_currentScene'
        private Scene.Scene _currentScene;

        /// <summary>
        /// METHOD: add a scene to a sceneList
        /// </summary>
        /// <param name="sceneName">Name of the scene</param>
        /// <param name="newScene">Scene object</param>
        public void AddScene(string sceneName, Scene.Scene newScene)
        {
            _scenes.Add(sceneName, newScene);
        }

        /// <summary>
        /// METHOD: remove the scene from the list
        /// </summary>
        /// <param name="sceneName">Name of the scene which needs to be removed</param>
        public void RemoveScene(string sceneName)
        {
            _scenes.Remove(sceneName);
        }

        /// <summary>
        /// METHOD: sets a scene to a current scene
        /// </summary>
        /// <param name="sceneName"></param>
        /// <returns></returns>
        public Scene.Scene SetScene(string sceneName)
        {
            _currentScene = _scenes[sceneName];
            return _currentScene;
        }
    }
}
