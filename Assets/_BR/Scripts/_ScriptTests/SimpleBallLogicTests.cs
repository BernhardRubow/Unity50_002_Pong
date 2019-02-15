
using System.Collections;
using System.Collections.Generic;
using nvp.interfaces;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    
    public class SimpleBallLogicTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Constructor_WhenInstatiated_IsNotNull()
        {
            // Use the Assert class to test conditions
            IBallModel bl = new NvpSimpleBallModel();
            Assert.IsNotNull(bl);
        }

        [Test]
        public void Should_ReflectDownwards_WhenHittingTopWall()
        {
            IBallModel bl = new NvpSimpleBallModel();
            Vector3 dir = new Vector3(1, 1, 0);

            Vector3 newDir = bl.CalculateNewDirAfterWallHit(dir);
            Assert.Less(newDir.y, 0f);

        }

        [Test]
        public void Should_ReflectUpwards_WhenHittingBottomWall()
        {
            IBallModel bl = new NvpSimpleBallModel();
            Vector3 dir = new Vector3(1, -1, 0);

            Vector3 newDir = bl.CalculateNewDirAfterWallHit(dir);
            Assert.Greater(newDir.y, 0f);
        }

        [Test]
        public void Should_ReflectRight_WhenHittingLeftPlayer()
        {
            IBallModel bl = new NvpSimpleBallModel();
            Vector3 dir = new Vector3(-1, -1, 0);

            Vector3 newDir = bl.CalculateNewDirAfterPlayerHit(dir);
            Assert.Greater(newDir.x, 0f);
        }

        [Test]
        public void Should_ReflectLeft_WhenHittingRightPlayer()
        {
            IBallModel bl = new NvpSimpleBallModel();
            Vector3 dir = new Vector3(1, 1, 0);

            Vector3 newDir = bl.CalculateNewDirAfterPlayerHit(dir);
            Assert.Less(newDir.x, 0f);
        }

        [Test]
        public void GetStartupDirection_Should_be_valid()
        {
            IBallModel bl = new NvpSimpleBallModel();
            Vector3 dir = bl.GetStartupDirection();

            Assert.That(dir.x, dir.x > 0f 
                ? Is.EqualTo(1).Within(0.000001f) 
                : Is.EqualTo(-1).Within(0.000001f));
        }

        [Test]
        public void CalcNewStartSpeed_SpeedfactorGiven_ReturnsValidSpeed([Random(0, 20, 5)] int x)
        {
            IBallModel bl = new NvpSimpleBallModel();
            float expextedResult = x + (x / 5.0f);
            float result = bl.CalcNewSpeed(x);
            Debug.LogFormat("{2}: {0} - {1}", result, expextedResult, x);
            Assert.That(expextedResult, Is.EqualTo(bl.CalcNewSpeed(x)).Within(0.001f));
           

            var expectedResult = x + ((x*2 - x) / 2f  );
            
            Assert.That(bl.CalcNewStartSpeed(x*2), Is.EqualTo(expectedResult).Within(0.0000001f));
        }
    }
    
}

