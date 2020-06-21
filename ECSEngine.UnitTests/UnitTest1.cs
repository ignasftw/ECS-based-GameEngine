using System;
using ECSEngine.Component.Rendering;
using ECSGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using System.Drawing;
using Microsoft.Xna.Framework.Graphics;

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
            //Act
            CreatingAnEntity(curScene);
            //Assert
            Assert.IsTrue(curScene.entities.Count > 0);
        }
        [TestMethod]
        public void IsSuccessfullyCreated_NotCreatingEntity_True()
        {
            //Arrange
            Scene.Scene curScene;
            curScene = new Scene.Scene();
            //Act
            //Same as first one but not running
            //CreatingAnEntity(curScene);
            //Assert
            Assert.IsFalse(curScene.entities.Count > 0);
        }

        void CreatingAnEntity(Scene.Scene curScene)
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
            Vector2.Zero
            )
            );
        }
    }
}
