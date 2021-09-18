using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class GotoNextStepTest
    {
        [Test]
        public void InitialTaskCounterPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreEqual(gtns.getTaskCounter(), 0);
        }
        [Test]
        public void InitialSectionCounterPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreEqual(gtns.getSectionCounter(), 0);
        }
        [Test]
        public void InitialActiveListPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreEqual(gtns.getActiveList(), null);
        }
        [Test]
        public void InitialSubTitleListPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreNotEqual(gtns.getSubtitleList(), null);
            Assert.AreEqual(gtns.getSubtitleList().Length, 5);
        }
        [Test]
        public void InitialCafeListPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreNotEqual(gtns.getCafeList(), null);
        }
        [Test]
        public void InitialPCListPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreNotEqual(gtns.getPCList(), null);
        }
        [Test]
        public void InitialPrinterListPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            Assert.AreNotEqual(gtns.getPrinterList(), null);
        }
        [Test]
        public void SetBackTextPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            int sc = gtns.getSectionCounter();
            int tc = gtns.getTaskCounter();
            gtns.SetBackText();
            Assert.AreEqual(gtns.getSectionCounter(), sc);
            Assert.AreEqual(gtns.getTaskCounter(), tc);
            Assert.AreEqual(gtns.getActiveList(), null);
        }
        [Test]
        public void SetNextTextPasses()
        {
            GoToNextStep gtns = new GoToNextStep();
            int sc = gtns.getSectionCounter();
            int tc = gtns.getTaskCounter();
            gtns.SetNextText();
            Assert.AreEqual(gtns.getSectionCounter(), sc);
            Assert.AreEqual(gtns.getTaskCounter(), tc);
            Assert.AreEqual(gtns.getActiveList(), null);
        }
    }
}
