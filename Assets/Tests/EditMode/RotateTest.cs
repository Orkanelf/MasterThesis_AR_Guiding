using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RotateTest
    {
        [Test]
        public void InitialXValuePasses()
        {
            Rotate r = new Rotate();
            Assert.AreEqual(r.rotationSpeed_X, 0);
        }
        [Test]
        public void InitialYValuePasses()
        {
            Rotate r = new Rotate();
            Assert.AreEqual(r.rotationSpeed_Y, 0);
        }
        [Test]
        public void InitialZValuePasses()
        {
            Rotate r = new Rotate();
            Assert.AreEqual(r.rotationSpeed_Z, 0);
        }
    }
}
