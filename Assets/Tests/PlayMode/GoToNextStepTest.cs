using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.UI;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class GoToNextStepTest
    {
        private GoToNextStep initializeGTNS()
        {
            GoToNextStep gtns = new GoToNextStep();
            gtns.englishVoices = new GameObject();
            gtns.germanVoices = new GameObject();
            gtns.buttonBack = (new GameObject().AddComponent(typeof(ButtonConfigHelper)) as ButtonConfigHelper).gameObject;
            gtns.buttonHideVirtualModel = (new GameObject().AddComponent(typeof(ButtonConfigHelper)) as ButtonConfigHelper).gameObject;
            gtns.buttonLanguage = (new GameObject().AddComponent(typeof(ButtonConfigHelper)) as ButtonConfigHelper).gameObject;
            gtns.buttonNext = (new GameObject().AddComponent(typeof(ButtonConfigHelper)) as ButtonConfigHelper).gameObject;
            gtns.buttonSoundOff = (new GameObject().AddComponent(typeof(ButtonConfigHelper)) as ButtonConfigHelper).gameObject;
            gtns.title = new GameObject().AddComponent(typeof(Text)) as Text;
            gtns.subtitle = new GameObject().AddComponent(typeof(Text)) as Text;
            gtns.textfield = new GameObject().AddComponent(typeof(Text)) as Text;

            gtns.toggle = new GameObject().AddComponent(typeof(FollowMeToggle)) as FollowMeToggle;

            gtns.success = new GameObject().AddComponent(typeof(AudioSource)) as AudioSource;
            gtns.scanned = new GameObject().AddComponent(typeof(AudioSource)) as AudioSource;

            gtns.voiceCofe_de = new List<AudioSource>();
            gtns.voiceCofe_de.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);
            gtns.voiceCofe_en = new List<AudioSource>();
            gtns.voiceCofe_en.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);

            gtns.voicePrinter_de = new List<AudioSource>();
            gtns.voicePrinter_de.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);
            gtns.voicePrinter_en = new List<AudioSource>();
            gtns.voicePrinter_en.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);

            gtns.voicePC_de = new List<AudioSource>();
            gtns.voicePC_de.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);
            gtns.voicePC_en = new List<AudioSource>();
            gtns.voicePC_en.Add(new GameObject().AddComponent(typeof(AudioSource)) as AudioSource);

            gtns.animationsCofe = new List<GameObject>();
            gtns.animationsCofe.Add(new GameObject());
            gtns.animationsPC = new List<GameObject>();
            gtns.animationsPC.Add(new GameObject());
            gtns.animationsPrinter = new List<GameObject>();
            gtns.animationsPrinter.Add(new GameObject());

            gtns.Start();

            return gtns;
        }

        [UnityTest]
        public IEnumerator InitialSituationPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, true);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            Assert.AreEqual(gtns.buttonLanguage.activeInHierarchy, true);
            Assert.AreEqual(gtns.buttonSoundOff.activeInHierarchy, true);
            Assert.AreEqual(gtns.buttonNext.activeInHierarchy, false);
            Assert.AreEqual(gtns.buttonBack.activeInHierarchy, false);
            Assert.AreEqual(gtns.buttonHideVirtualModel.activeInHierarchy, false);
        }
        [UnityTest]
        public IEnumerator InitialQRCodeScannedPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("PC");
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, true);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            Assert.AreEqual(gtns.buttonLanguage.activeInHierarchy, true);
            Assert.AreEqual(gtns.buttonSoundOff.activeInHierarchy, true);
            Assert.AreEqual(gtns.buttonNext.activeInHierarchy, true);
            Assert.AreEqual(gtns.buttonBack.activeInHierarchy, false);
            Assert.AreEqual(gtns.buttonHideVirtualModel.activeInHierarchy, true);
        }

        [UnityTest]
        public IEnumerator ButtonChangeLanguagePasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            yield return new WaitForSeconds(Time.deltaTime);

            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, true);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            gtns.LanguageChanged();
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, false);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, true);
            gtns.LanguageChanged();
            yield return new WaitForSeconds(Time.deltaTime);
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, true);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            Assert.AreEqual(gtns.title.text, "AR Guiding Application");
            
        }

        [UnityTest]
        public IEnumerator ButtonChangeSoundPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, true);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            gtns.SoundOff();
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, false);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            gtns.SoundOff();
            Assert.AreEqual(gtns.englishVoices.activeInHierarchy, true);
            Assert.AreEqual(gtns.germanVoices.activeInHierarchy, false);
            yield return new WaitForSeconds(Time.deltaTime);
        }

        [UnityTest]
        public IEnumerator ScanPCPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("PC");
            Assert.AreEqual(gtns.title.text, "Change the hard drive");
            Assert.AreEqual(gtns.subtitle.text, "Solve the following Tasks:");
            Assert.AreEqual(gtns.textfield.text, "I   Preparation - Open the computer\n(4 steps)\n" +
            "II  Execution - Change the hard drive\n(5 steps)\n" +
            "III Post-processing - Close the computer\n(4 steps)");
            yield return new WaitForSeconds(Time.deltaTime);
        }

        [UnityTest]
        public IEnumerator ScanCoffeePasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("Caffee");
            Assert.AreEqual(gtns.title.text, "Make yourself a coffee");
            Assert.AreEqual(gtns.subtitle.text, "Solve the following Tasks:");
            Assert.AreEqual(gtns.textfield.text, "I   Preparation - Prepare the machine\n(7 steps)\n" +
            "II  Execution - Make the coffee\n(3 steps)\n" +
            "III Post-processing - Tidy up\n(5 steps)\n");
            yield return new WaitForSeconds(Time.deltaTime);
        }

        [UnityTest]
        public IEnumerator ScanPrinterPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("Printer");
            Assert.AreEqual(gtns.title.text, "Change the printer cartridge");
            Assert.AreEqual(gtns.subtitle.text, "Solve the following Tasks:");
            Assert.AreEqual(gtns.textfield.text, "I   Preparation - Open the printer\n(2 steps)\n" +
            "II  Execution - Change the printer cartridge\n(4 steps)\n" +
            "III Post-processing - Close the printer\n(1 step)\n");
            yield return new WaitForSeconds(Time.deltaTime);
        }

        [UnityTest]
        public IEnumerator ButtonNextPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("PC");
            gtns.SetNextText();
            Assert.AreEqual(gtns.buttonBack.activeInHierarchy, true);
            Assert.AreEqual(gtns.subtitle.text, "I / III Preparation");

            yield return new WaitForSeconds(Time.deltaTime);
        }

        [UnityTest]
        public IEnumerator ButtonNextHidesInEndPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("Printer");
            int counter = 0;
            foreach(List<string> list in gtns.getPrinterList())
            {
                foreach (string e in list)
                {
                    counter++;
                }
            }
            for (int i = 1; i < counter; i++)
            {
                gtns.SetNextText();
            }

            Assert.AreEqual(gtns.buttonNext.activeInHierarchy, false);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        [UnityTest]
        public IEnumerator ButtonBackPasses()
        {
            GoToNextStep gtns = this.initializeGTNS();
            gtns.QRCodeScanned("PC");
            gtns.SetNextText();
            gtns.SetBackText();
            Assert.AreEqual(gtns.buttonBack.activeInHierarchy, false);
            Assert.AreEqual(gtns.title.text, "Change the hard drive");
            Assert.AreEqual(gtns.subtitle.text, "Solve the following Tasks:");
            Assert.AreEqual(gtns.textfield.text, "I   Preparation - Open the computer\n(4 steps)\n" +
            "II  Execution - Change the hard drive\n(5 steps)\n" +
            "III Post-processing - Close the computer\n(4 steps)");

            yield return new WaitForSeconds(Time.deltaTime);
        }

    }
}
