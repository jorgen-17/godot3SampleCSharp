using System;
using Godot;
using NUnit.Framework;

namespace godot3dSample.test
{
    [TestFixture]
    public class ThirdPersonCameraTests
    {
        [Test]
        public void ChangingCenterShouldResultInSameRotation()
        {
            var degree = 45;
            
            var point1 = new Vector2(0.0f, 50.0f);
            var center1 = new Vector2(0f, 0f);

            var rotatedCoordinate1 = ThirdPersonCamera.RotateAroundCenter(point1, center1, degree);
            var rotated1X = Math.Abs(rotatedCoordinate1.x - point1.x);
            var rotated1Y = Math.Abs(rotatedCoordinate1.y - point1.y);
            
            var point2 = new Vector2(0f, 0f);
            var center2 = new Vector2(0f, -50.0f);

            var rotatedCoordinate2 = ThirdPersonCamera.RotateAroundCenter(point2, center2, degree);
            var rotated2X = Math.Abs(rotatedCoordinate2.x - point2.x);
            var rotated2Y = Math.Abs(rotatedCoordinate2.y - point2.y);
            
            Assert.That(rotated1X, Is.EqualTo(rotated2X).Within(1).Percent);
            Assert.That(rotated1Y, Is.EqualTo(rotated2Y).Within(1).Percent);
        } 
    }
}