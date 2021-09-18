using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HideVirtualModelTest
    {
        /// <summary>
        /// Checks if the initial state of ModeChanged is false
        /// </summary>
        [Test]
        public void ModeChangedInitialPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            Assert.AreEqual(hvm.getModeChanged(), false);
        }

        /// <summary>
        /// Checks if the state of ModeChanged is true after one trigger
        /// </summary>
        [Test]
        public void ModeChangedAfterTriggerPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            hvm.HideVirtualModelChanged();
            Assert.AreEqual(hvm.getModeChanged(), true);
        }

        /// <summary>
        /// Checks if the state of ModeChanged is true after two triggers
        /// </summary>
        [Test]
        public void ModeChangedAfterDoubleTriggerPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            hvm.HideVirtualModelChanged();
            hvm.HideVirtualModelChanged();
            Assert.AreEqual(hvm.getModeChanged(), true);
        }

        /// <summary>
        /// Checks if the initial state of HideVirtualModel is false
        /// </summary>
        [Test]
        public void HideVirtualModelInitialPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            Assert.AreEqual(hvm.getShowVirtualModel(), true);
        }

        /// <summary>
        /// Checks if the state of HideVirtualModel is true after one trigger.
        /// </summary>
        [Test]
        public void HideVirtualModelChangedAfterTriggerPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            hvm.HideVirtualModelChanged();
            Assert.AreEqual(hvm.getShowVirtualModel(), false);
        }

        /// <summary>
        /// Checks if the state of HideVirtualModel is true after two triggers.
        /// </summary>
        [Test]
        public void HideVirtualModelChangedAfterDoubleTriggerPasses()
        {
            HideVirtualModel hvm = new HideVirtualModel();
            hvm.HideVirtualModelChanged();
            hvm.HideVirtualModelChanged();
            Assert.AreEqual(hvm.getShowVirtualModel(), true);
        }
    }
}
