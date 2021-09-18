using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HideVirtualModelTest
    {
        [UnityTest]
        public IEnumerator ButtonHideVirtualModelInitialPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(hvm.getShowVirtualModel(), true);
        }
        [UnityTest]
        public IEnumerator ButtonHideVirtualModelPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            hvm.HideVirtualModelChanged();
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(hvm.getShowVirtualModel(), false);
            hvm.HideVirtualModelChanged();
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(hvm.getShowVirtualModel(), true);
        }
    }
}
