using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services.Locator
{
    public class GameObjectsLocator
    {
        private List<GameObjectsDictionary> gameObjects = new List<GameObjectsDictionary>();

        public void RegisterGameObject(string name, GameObject gameObject)
        {
            gameObjects.Add(new GameObjectsDictionary(name, gameObject));
        }

        public GameObject GetGameObjectByName(string name)
        {
            return gameObjects.FirstOrDefault(g => g.name == name).gameObject;
        }
    }
}