using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RotateTest
    {
        [UnityTest]
        public IEnumerator RotateXPasses()
        {
            var gameObject = new GameObject();
            var screwdriver = gameObject.AddComponent<Rotate>();
            screwdriver.rotationSpeed_X = 20;
            yield return new WaitForSeconds(Time.deltaTime);

            Assert.AreNotEqual(screwdriver.gameObject.transform.rotation.x, 0);
            Assert.AreEqual(screwdriver.gameObject.transform.rotation.y, 0);
            Assert.AreEqual(screwdriver.gameObject.transform.rotation.z, 0);
        }
        [UnityTest]
        public IEnumerator RotateYPasses()
        {
            var gameObject = new GameObject();
            var screwdriver = gameObject.AddComponent<Rotate>();
            screwdriver.rotationSpeed_Y = 20;
            yield return new WaitForSeconds(Time.deltaTime);

            Assert.AreEqual(screwdriver.gameObject.transform.rotation.x, 0);
            Assert.AreNotEqual(screwdriver.gameObject.transform.rotation.y, 0);
            Assert.AreEqual(screwdriver.gameObject.transform.rotation.z, 0);
        }
        [UnityTest]
        public IEnumerator RotateZPasses()
        {
            var gameObject = new GameObject();
            var screwdriver = gameObject.AddComponent<Rotate>();
            screwdriver.rotationSpeed_Z = 20;
            yield return new WaitForSeconds(Time.deltaTime);

            Assert.AreEqual(screwdriver.gameObject.transform.rotation.x, 0);
            Assert.AreEqual(screwdriver.gameObject.transform.rotation.y, 0);
            Assert.AreNotEqual(screwdriver.gameObject.transform.rotation.z, 0);
        }
        [UnityTest]
        public IEnumerator RotateAllPasses()
        {
            var gameObject = new GameObject();
            var screwdriver = gameObject.AddComponent<Rotate>();
            screwdriver.rotationSpeed_X = 20;
            screwdriver.rotationSpeed_Y = 20;
            screwdriver.rotationSpeed_Z = 20;
            yield return new WaitForSeconds(Time.deltaTime);

            Assert.AreNotEqual(screwdriver.gameObject.transform.rotation.x, 0);
            Assert.AreNotEqual(screwdriver.gameObject.transform.rotation.y, 0);
            Assert.AreNotEqual(screwdriver.gameObject.transform.rotation.z, 0);
        }
    }
}
