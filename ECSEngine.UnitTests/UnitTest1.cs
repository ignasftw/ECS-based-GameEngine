using System;
using ECSEngine.Component.Rendering;
using ECSGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;

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
