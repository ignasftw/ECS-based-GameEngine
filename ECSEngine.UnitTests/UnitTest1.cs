using System;
using System.Collections.Generic;
using ECSEngine.Component.Rendering;
using ECSEngine.Inputs;
using ECSGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ECSEngine.UnitTests
{
    [TestClass]
    public class InitializationTests
    {

        [TestMethod]
        public void IsSuccessfullyCreated_CreatingEntity_True()
        {
            //Arrange
            Scene.Scene curScene;
            curScene = new Scene.Scene();
            //INITIALIZE collider system because it requires to gather its components
            ECSGame.Systems.ColiderSystem.CollisionSystem _colliderSystem = new ECSGame.Systems.ColiderSystem.CollisionSystem();
            //Act
            CreatingAnEntity(curScene, _colliderSystem);
            //Assert
            Assert.IsTrue(curScene._entities.Count > 0);
        }
        [TestMethod]
        public void IsSuccessfullyCreated_NotCreatingEntity_False()
        {
            //Arrange
            Scene.Scene curScene;
            curScene = new Scene.Scene();
            //Act
            //Same as first one but not running, to make sure that the scene is initially empty
            //Assert
            //If the current scene has no entities it should return false
            Assert.IsFalse(curScene._entities.Count > 0);
        }
        [TestMethod]
        public void HadSceneChanged_ChangingTheScene_EqualToZero()
        {
            //Arrange
            //DECLARE a SceneManager which will store scenes
            SceneManager sceneManager = new SceneManager();
            //DECLARE a current scene which will allow adding entities
            Scene.Scene currentScene;
            //Add scene into a manager
            sceneManager.AddScene("TestScene1",new Scene.Scene());
            //Set a current scene keeping a reference of which scene is active
            currentScene = sceneManager.SetScene("TestScene1");
            //Add another scene to a manager
            sceneManager.AddScene("TestScene2", new Scene.Scene());
            //INITIALIZE collider system because it requires to gather its components
            ECSGame.Systems.ColiderSystem.CollisionSystem _colliderSystem = new ECSGame.Systems.ColiderSystem.CollisionSystem();
            //Add entities into 1st scene to make sure that there is more than 1 entity
            CreatingAnEntity(currentScene, _colliderSystem);
            //Change into a different scene
            currentScene = sceneManager.SetScene("TestScene2");
            //Assert
            //If scenes has changed successfully then the entity count should be zero
            Assert.AreEqual(0, currentScene._entities.Count);
        }
        [TestMethod]
        public void HadSceneChanged_SceneHasNotChanged_EqualToOne()
        {
            //Arrange
            //DECLARE a SceneManager which will store scenes
            SceneManager sceneManager = new SceneManager();
            //DECLARE a current scene which will allow adding entities
            Scene.Scene currentScene;
            //Add scene into a manager
            sceneManager.AddScene("TestScene1", new Scene.Scene());
            //Set a current scene keeping a reference of which scene is active
            currentScene = sceneManager.SetScene("TestScene1");
            //Add another scene to a manager
            sceneManager.AddScene("TestScene2", new Scene.Scene());
            //INITIALIZE collider system because it requires to gather its components
            ECSGame.Systems.ColiderSystem.CollisionSystem _colliderSystem = new ECSGame.Systems.ColiderSystem.CollisionSystem();
            //Add entities into 1st scene to make sure that there is more than 1 entity
            CreatingAnEntity(currentScene, _colliderSystem);
            //Assert
            //If scenes has changed successfully then the entity count should be zero
            Assert.AreEqual(1, currentScene._entities.Count);
        }
        void CreatingAnEntity(Scene.Scene curScene, ECSGame.Systems.ColiderSystem.CollisionSystem colliderSystem)
        {
            Entity.Entity testEntity =
            curScene.AddEntity(
            new Entity.Entity(
            new Vector2(0, 0),
            0.1f,
            name: "Floor collision",
            tag: 0
            )
            );

            testEntity.AddComponent(
            new ECSGame.Component.Physics.Colliders.RectCollider(
            testEntity,
            3500f,
            (float)0 / 2,
            Vector2.Zero,
            colliderSystem.AddCollider
            )
            );
        }
    }
}
