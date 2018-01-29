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
            var degree = 5;
            
            var point1 = new Vector2(0.0f, 0.5f);
            var center1 = new Vector2(0f, 0f);

            var rotatedCoordinate1 = ThirdPersonCamera.RotateAroundCenter(point1, center1, degree);
            var rotated1X = Math.Abs(rotatedCoordinate1.x - point1.x);
            var rotated1Y = Math.Abs(rotatedCoordinate1.x - point1.x);
            
            var point2 = new Vector2(0f, 0f);
            var center2 = new Vector2(0f, -0.5f);

            var rotatedCoordinate2 = ThirdPersonCamera.RotateAroundCenter(point2, center2, degree);
            var rotated2X = Math.Abs(rotatedCoordinate2.x - point2.x);
            var rotated2Y = Math.Abs(rotatedCoordinate2.x - point2.x);
            
            Assert.AreEqual(rotated1X, rotated2X, "since the point and the center are the same disatnce apart and " +
                                                  "getting rotated by the same number of degrees, they should have been " +
                                                  "displaced by the same amount in the X");
            Assert.AreEqual(rotated1Y, rotated2Y, "since the point and the center are the same disatnce apart and " +
                                                  "getting rotated by the same number of degrees, they should have been " +
                                                  "displaced by the same amount in the Y");
        } 
    }
}