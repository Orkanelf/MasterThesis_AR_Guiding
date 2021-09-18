
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GoToNextStep : MonoBehaviour
{
    public Text title;
    public Text subtitle;
    public Text textfield;

    public GameObject buttonBack;
    public GameObject buttonNext;
    public GameObject buttonHideVirtualModel;
    public GameObject buttonLanguage;
    public GameObject buttonSoundOff;

    public AudioSource scanned;
    public AudioSource success;

    public GameObject englishVoices;
    public GameObject germanVoices;

    public FollowMeToggle toggle;

    public List<GameObject> animationsCofe;
    public List<GameObject> animationsPC;
    public List<GameObject> animationsPrinter;

    public List<AudioSource> voicePC_en;
    public List<AudioSource> voicePrinter_en;
    public List<AudioSource> voiceCofe_en;
    public List<AudioSource> voicePC_de;
    public List<AudioSource> voicePrinter_de;
    public List<AudioSource> voiceCofe_de;

    private int taskCounter = 0;
    private int sectionCounter = 0;
    private int counter = 0;
    private StreamWriter myWriter;
    private bool isEnglishLanguage = true;
    private bool isSoundOn = true;

    private Dictionary<EScenario, string> titleDict_en  = new Dictionary<EScenario, string>();
    private Dictionary<EScenario, string> titleDict_de =  new Dictionary<EScenario, string>();
    private Dictionary<EScenario, List<string>[]> textDict_en = new Dictionary<EScenario, List<string>[]>();
    private Dictionary<EScenario, List<string>[]> textDict_de = new Dictionary<EScenario, List<string>[]>();

    private Dictionary<EScenario, List<GameObject>> animationDict = new Dictionary<EScenario, List<GameObject>>();
    private Dictionary<EScenario, List<AudioSource>> voiceDict_en = new Dictionary<EScenario, List<AudioSource>>();
    private Dictionary<EScenario, List<AudioSource>> voiceDict_de = new Dictionary<EScenario, List<AudioSource>>();

    private string[] subtitleList_en = {
        "Solve the following Tasks:",
        "I / III Preparation",
        "II / III Execution",
        "III / III Post-processing",
        "Congratulations!"
    };
    private string[] subtitleList_de = {
        "Löse die folgenden Aufgaben:",
        "I / III Vorbereitung",
        "II / III Durchführung",
        "III / III Nachbereitung",
        "Herzlichen Glückwunsch!"
    };

    private List<string>[] StringListPC_en = {
        new List<string>(){
            "I   Preparation - Open the computer\n(4 steps)\n" +
            "II  Execution - Change the hard drive\n(6 steps)\n" +
            "III Post-processing - Close the computer\n(4 steps)"
        },
        new List<string>(){
            "Loosen the screw on the top back of the computer\n(step 1 of 4)",
            "Open the top cover\n(step 2 of 4)",
            "Loosen the 2 screws next to the handles\n(step 3 of 4)",
            "Open both side covers with the handles\n(step 4 of 4)"
        },
        new List<string>(){
            "Disconnect both cables from the hard drive\n(step 1 of 6)\n\n(hint: The datacable has a button that needs to be pressed bevore disconnecting.)",
            "Loosen the 4 screws on the hard drive - 2 from each side\n(step 2 of 6)\n\n(hint: It might help to turn of the virtual model while working inside the computer)",
            "Remove the old hard drive\n(step 3 of 6)",
            "Insert the new hard drive\n(step 4 of 6)",
            "Tighten the 4 screws on the new hard drive - 2 from each side\n(step 5 of 6)",
            "Connect both cables to the hard drive\n(step 6 of 6)"
        },
        new List<string>(){
            "Close both side covers, note the grooves at the bottom\n(step 1 of 4)",
            "Tighten the 2 screws next to the handles\n(step 2 of 4)",
            "Close the top cover\n(step 3 of 4)",
            "Tighten the screw on the top back of the computer\n(step 4 of 4)"
        },
        new List<string>(){
            "You solved the task!\n" +
            "(Scan a another QR code for a further task.)"
        }
    };
    private List<string>[] StringListPrinter_en = {
        new List<string>(){
            "I   Preparation - Open the printer\n(2 steps)\n" +
            "II  Execution - Change the printer cartridge\n(4 steps)\n" +
            "III Post-processing - Close the printer\n(1 step)\n"
        },
        new List<string>(){
            "Open the paper tray\n(step 1 of 2)",
            "Open the top cover of the printer\n(step 2 of 2)"
        },
        new List<string>(){
            "Take out the printer cartridge\n(step 1 of 4)",
            "Take the protector off the new cartridge\n(step 2 of 4)",
            "Put the protector onto the old cartridge\n(step 3 of 4)",
            "Put the new cartridge into the printer until it clicks\n(step 4 of 4)"
        },
        new List<string>(){
            "Close the printer\n(step 1 of 1)",
        },
        new List<string>(){
            "You solved the task!\n" +
            "(Scan a another QR code for a further task.)"
        }
    };
    private List<string>[] StringListCafe_en = {
        new List<string>(){
            "I   Preparation - Prepare the machine\n(7 steps)\n" +
            "II  Execution - Make the coffee\n(3 steps)\n" +
            "III Post-processing - Tidy up\n(5 steps)\n"
        },
        new List<string>(){
            "Take out the water tank by opening the lid\n(step 1 of 7)",
            "Fill the water tank with water\n(step 2 of 7)",
            "Put the tank back\n(step 3 of 7)",
            "Put a cup under the machine\n(step 4 of 7)",
            "Open the lever\n(step 5 of 7)",
            "Put a capsule into the machine like animated\n(step 6 of 7)",
            "Close the lever strongly\n(step 7 of 7)"
        },
        new List<string>(){
            "Press the coffee Button\n(step 1 of 3)",
            "Wait for the coffee to be ready\n(circa 50 sec.)\n(step 2 of 3)",
            "Take your cup\n(step 3 of 3)"
        },
        new List<string>(){
            "Open the lever\n(step 1 of 5)",
            "Open the trash compartment\n(step 2 of 5)",
            "Throw away the used caspule\n(step 3 of 5)",
            "Close the trash compartment\n(step 4 of 5)",
            "Close the lever\n(step 5 of 5)"
        },
        new List<string>(){
            "Enjoy your coffee!\n" +
            "(Scan a another QR code for a further task.)"
        }
    };
    private List<string>[] StringListPC_de = {
        new List<string>(){
            "I   Vorbereitung - Öffne den Computer\n(4 Schritte)\n" +
            "II  Ausführung - Wechsele die Festplatte\n(6 Schritte)\n" +
            "III Nachbereitung - Schließe den Computer\n(4 Schritte)"
        },
        new List<string>(){
            "Löse die Schraube in der Mitte oben auf der Rückseite des Computers\n(Schritt 1 von 4)",
            "Öffne die obere Abdeckung\n(Schritt 2 von 4)",
            "Löse die zwei Schrauben neben den Griffen\n(Schritt 3 von 4)",
            "Öffne die beiden seitlichen Abdeckungen mit hilfe der Griffe\n(Schritt 4 von 4)"
        },
        new List<string>(){
            "Löse beide Kabel von der Festplatte\n(Schritt 1 von 6)\n\n(Hinweis: Das Datenkabel hat einen Knopf der zum Lösen gedrückt werden muss.)",
            "Löse die 4 Schrauben von der Festplatte - 2 von jeder Seite\n(Schritt 2 von 6)\n\n(Hinweis: Es kann helfen das virtuelle Modell auszuschalten, während man im Computer arbeitet.)",
            "Entferne die alte Festplatte\n(Schritt 3 von 6)",
            "Stecke die neue Festplatte rein\n(Schritt 4 von 6)",
            "Ziehe die 4 Schrauben an der neuen Festplatte an - 2 von jeder Seite\n(Schritt 5 von 6)",
            "Verbinde die beiden Kabel mit der Festplatte\n(Schritt 6 von 6)"
        },
        new List<string>(){
            "Schließe die bieden seitlichen Abdeckungen, beachte die Einkerbungen am unteren Ende\n(Schritt 1 von 4)",
            "Ziehe die 2 Schrauben neben den Griffen fest\n(Schritt 2 von 4)",
            "Schließe die obere Abdeckung\n(Schritt 3 von 4)",
            "Ziehe die Schraube am hinteren oberen Ende des Computers fest\n(Schritt 4 von 4)"
        },
        new List<string>(){
            "Du hast die Aufgabe erledigt!\n" +
            "(Scanne einen anderen QR Code für eine weitere Aufgaben.)"
        }
    };
    private List<string>[] StringListPrinter_de = {
        new List<string>(){
            "I   Vorbereitung - Öffne den Drucker\n(2 Schritte)\n" +
            "II  Ausführung - Tausche den Drucker Toner\n(4 Schritte)\n" +
            "III Nachbereitung - Schließe den Drucker\n(1 Schritt)\n"
        },
        new List<string>(){
            "Öffne das Papierfach\n(Schritt 1 von 2)",
            "Öffne die obere Abdeckung vom Drucker\n(Schritt 2 von 2)"
        },
        new List<string>(){
            "Nimm den Drucker Toner heraus\n(Schritt 1 von 4)",
            "Löse die Toner Abdeckung von dem neuen Toner\n(Schritt 2 von 4)",
            "Stecke die Toner Abdeckung auf den alten Toner\n(Schritt 3 von 4)",
            "Stecke den neuen Toner in den Drucker\n(Schritt 4 von 4)"
        },
        new List<string>(){
            "Schließe den Drucker\n(Schritt 1 von 1)",
        },
        new List<string>(){
            "Du hast die Aufgabe erledigt!\n" +
            "(Scanne einen anderen QR Code für eine weitere Aufgaben.)"
        }
    };
    private List<string>[] StringListCafe_de = {
        new List<string>(){
            "I   Vorbereitung - Bereite die Maschine vor\n(7 Schritte)\n" +
            "II  Ausführung - Mach dir einen Kaffee\n(3 Schritte)\n" +
            "III Nachbereitung - Räume auf\n(5 Schritte)\n"
        },
        new List<string>(){
            "Nimm den Wassertank heraus indem du den Deckel öffnest\n(Schritt 1 von 7)",
            "Fülle den Wassertank mit Wasser\n(Schritt 2 von 7)",
            "Steck den Wassertank zurück\n(Schritt 3 von 7)",
            "Stelle eine Tasse unter die Maschine\n(Schritt 4 von 7)",
            "Öffne den Hebel\n(Schritt 5 von 7)",
            "Lege eine Kaffekapsel in die Maschine wie dargestellt\n(Schritt 6 von 7)",
            "Schließe den Hebel kräftig\n(Schritt 7 von 7)"
        },
        new List<string>(){
            "Drücke den Kaffee Knopf\n(Schritt 1 von 3)",
            "Warte bis der Kaffee fertig ist\n(circa 50 Sec.)\n(Schritt 2 von 3)",
            "Nimm dir die Tasse\n(Schritt 3 von 3)"
        },
        new List<string>(){
            "Öffne den Hebel\n(Schritt 1 von 5)",
            "Öffne das Müllfach\n(Schritt 2 von 5)",
            "Schmeiß die Kaffekapsel weg\n(Schritt 3 von 5)",
            "Schließe das Müllfach\n(Schritt 4 von 5)",
            "Schließe den Hebel\n(Schritt 5 von 5)"
        },
        new List<string>(){
            "Genieß den Kaffe!\n" +
            "(Scanne einen anderen QR Code für eine weitere Aufgaben.)"
        }
    };
    private List<string>[] activeList = null;
    private EScenario currentScenario = EScenario.Start;
    private enum EScenario {Start, PC, Printer, Cofe};

    private void ChangeAudios()
    {
        this.englishVoices.SetActive(this.isEnglishLanguage && this.isSoundOn);
        this.germanVoices.SetActive(!this.isEnglishLanguage && this.isSoundOn);
    }

    /// <summary>
    /// ChangeStep() is called if the text changes. This is when the next or back
    /// button is pressed or triggered by the method Start() if a new setup is initialized.
    /// </summary>
    private void ChangeStep()
    {
        this.HideAllAnimations();
        this.StopAllAudio();

        if (this.currentScenario != EScenario.Start)
        {
            if (this.isEnglishLanguage)
            {
                this.subtitle.text = this.subtitleList_en[this.sectionCounter];
                if (this.counter < this.voiceDict_en[this.currentScenario].Count)
                    this.voiceDict_en[this.currentScenario][this.counter].Play();
            }
            else
            { 
                this.subtitle.text = this.subtitleList_de[this.sectionCounter];
                if (this.counter < this.voiceDict_de[this.currentScenario].Count)
                    this.voiceDict_de[this.currentScenario][this.counter].Play();
            }

            if (this.taskCounter < this.activeList[this.sectionCounter].Count)
                this.textfield.text = this.activeList[this.sectionCounter][this.taskCounter];

            /// Check for animation
            if (this.counter < this.animationDict[this.currentScenario].Count)
                this.animationDict[this.currentScenario][this.counter].SetActive(true);
        }

        myWriter.WriteLine("Step Changed:" +
            "\n Scenario: " + this.currentScenario.ToString() +
            "\n Task: " + this.getTaskCounter() +
            "\n Section: " + this.getSectionCounter() +
            "\n General Counter: " + this.counter +
            "\n {0}, {1:G}\n\n", DateTime.Now.ToString("de-DE"), DateTime.Now.Kind);
    }

    /// <summary>
    /// This Methods deactivates all animations listed in public List<GameObject> animations;
    /// </summary>
    private void HideAllAnimations()
    {
        foreach (EScenario myScenario in System.Enum.GetValues(typeof(EScenario)))
        {
            if (this.animationDict[myScenario] != null)
            {
                foreach (GameObject animation in this.animationDict[myScenario])
                {
                    animation.SetActive(false);
                }
            }
        }
    }

    private void StopAllAudio()
    {
        this.englishVoices.SetActive(false);
        this.germanVoices.SetActive(false);
        this.ChangeAudios();

        if (this.currentScenario != EScenario.Start)
        {
            foreach (AudioSource audio in this.voiceDict_en[this.currentScenario])
            {
                audio.Stop();
            }
            foreach (AudioSource audio in this.voiceDict_de[this.currentScenario])
            {
                audio.Stop();
            }
        }
    }

    /// <summary>
    /// This method is called, if a QR Code is scanned. It prepares the right scenario.
    /// </summary>
    /// <param name="task">The task that should be explained. Possible values: "PC", "Printer", "Caffee"</param>
    public void QRCodeScanned(string task)
    {
        this.taskCounter = 0;
        this.sectionCounter = 0;
        this.counter = 0;
        this.activeList = null;
        this.buttonHideVirtualModel.SetActive(true);
        this.buttonBack.SetActive(false);
        this.buttonNext.SetActive(true);

        switch (task)
        {
            case "PC":
                this.currentScenario = EScenario.PC;
                break;
            case "Printer":
                this.currentScenario = EScenario.Printer;
                break;
            case "Caffee":
                this.currentScenario = EScenario.Cofe;
                break;
            default:
                this.currentScenario = EScenario.Start;
                break;
        }

        #region Language Configuration
        if (this.isEnglishLanguage)
        {
            this.title.text = this.titleDict_en[this.currentScenario];
            this.subtitle.text = this.subtitleList_en[this.sectionCounter];
            this.activeList = this.textDict_en[this.currentScenario];
        }
        else
        {
            this.title.text = this.titleDict_de[this.currentScenario];
            this.subtitle.text = this.subtitleList_de[this.sectionCounter];
            this.activeList = this.textDict_de[this.currentScenario];
        }
        #endregion

        this.scanned.Play();
        this.ChangeStep();
    }

    /// <summary>
    /// This method is triggered when the language button is clicked.
    /// It changes the state of the private isEnglishLanguage variable.
    /// </summary>
    public void LanguageChanged()
    {
        // Set Variable
        if (this.isEnglishLanguage)
            this.isEnglishLanguage = false;
        else
            this.isEnglishLanguage = true;

        // Set Audio
        this.ChangeAudios();

        // Set Text
        if (this.isEnglishLanguage)
        {
            this.buttonLanguage.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "Deutsch";
            this.buttonLanguage.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Sag \"Deutsch\"";
            this.buttonSoundOff.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "Sound off";
            this.buttonSoundOff.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Say \"Sound off\"";
            this.buttonHideVirtualModel.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "Hide virtual model";
            this.buttonHideVirtualModel.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Sag \"hide model\"";
            this.buttonBack.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "back";
            this.buttonBack.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Say \"back\"";
            this.buttonNext.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "next";
            this.buttonNext.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Say \"next\"";
            this.title.text = this.titleDict_en[this.currentScenario];
            this.activeList = this.textDict_en[this.currentScenario];
            if (this.currentScenario == EScenario.Start)
            {
                this.subtitle.text = "Please scan a QR code";
            }
        }
        else
        {
            this.buttonLanguage.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "English";
            this.buttonLanguage.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Say \"English\"";
            this.buttonSoundOff.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "Ton aus";
            this.buttonSoundOff.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Sag \"Ton aus\"";
            this.buttonHideVirtualModel.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "Virtuelles Modell ausblenden";
            this.buttonHideVirtualModel.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Sag \"Modell ausblenden\"";
            this.buttonBack.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "zurück";
            this.buttonHideVirtualModel.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Sag \"zurück\"";
            this.buttonNext.gameObject.GetComponent<ButtonConfigHelper>().MainLabelText = "weiter";
            this.buttonHideVirtualModel.gameObject.GetComponent<ButtonConfigHelper>().SeeItSayItLabelText = "Sag \"weiter\"";
            this.title.text = this.titleDict_de[this.currentScenario];
            this.activeList = this.textDict_de[this.currentScenario];
            if (this.currentScenario == EScenario.Start)
            {
                this.subtitle.text = "Bitte scanne einen QR Code";
            }
        }

        //Renew Text
        this.ChangeStep();
    }

    /// <summary>
    /// This Method is treiggerd when the SoundOff Button is triggerd.
    /// </summary>
    public void SoundOff()
    {
        // Set Variable
        if (this.isSoundOn)
            this.isSoundOn = false;
        else
            this.isSoundOn = true;

        //this.ChangeAudios();
        this.ChangeStep();
    }

    /// <summary>
    /// This method is called when the next button is pressed. It changes the text when the next step is requested.
    /// </summary>
    public void SetNextText()
    {
        if (this.currentScenario != EScenario.Start)
        {
            this.counter++;
            this.taskCounter++;

            /// New element is not anymore in block
            if (this.taskCounter >= this.activeList[this.sectionCounter].Count)
            {
                /// Block is not the last one
                if (this.sectionCounter < this.activeList.Length - 1)
                {
                    this.sectionCounter++;
                    this.taskCounter = 0;
                }
                /// Was already the last element in the last block
                else if (this.sectionCounter == this.activeList.Length - 1)
                {
                    this.taskCounter--;
                    this.taskCounter--;
                }
            }

            /// Check if it is the last element in the last block, if yes, disable the next button.
            if (this.sectionCounter == this.activeList.Length - 1 && this.taskCounter == this.activeList[this.sectionCounter].Count - 1)
            {
                this.buttonNext.SetActive(false);
                this.success.Play();
            }

            this.ChangeStep();
            this.buttonBack.SetActive(true);
        }
    }

    /// <summary>
    /// This method is called if the back button is pressed. It changes the text when the last step is requested.
    /// </summary>
    public void SetBackText()
    {
        if (this.currentScenario != EScenario.Start)
        {
            this.counter--;
            this.taskCounter--;

            /// New element is not anymore in block
            if (this.taskCounter <= -1)
            {
                /// Block is not the first one
                if (this.sectionCounter > 0)
                {
                    this.sectionCounter--;
                    this.taskCounter = this.activeList[this.sectionCounter].Count - 1;
                }
                /// Is already the first element in the first block
                else if (this.sectionCounter == 0)
                {
                    this.taskCounter++;
                    this.counter++;
                }
            }

            /// Check if it is the last element in the last block, if yes, disable the next button.
            if (this.sectionCounter == 0 && this.taskCounter == 0)
            {
                this.buttonBack.SetActive(false);
            }

            this.ChangeStep();
            this.buttonNext.SetActive(true);
        }
    }
    
    /// <summary>
    /// Start method, called for initial state and after a new scanned QR code
    /// </summary>
    public void Start()
    {
        this.toggle.SetFollowMeBehavior(true);
        this.titleDict_en.Add(EScenario.Start, "AR Guiding Application");
        this.titleDict_en.Add(EScenario.PC, "Change the hard drive");
        this.titleDict_en.Add(EScenario.Printer, "Change the printer cartridge");
        this.titleDict_en.Add(EScenario.Cofe, "Make yourself a coffee");

        this.textDict_en.Add(EScenario.Start, null);
        this.textDict_en.Add(EScenario.PC, this.StringListPC_en);
        this.textDict_en.Add(EScenario.Printer, this.StringListPrinter_en);
        this.textDict_en.Add(EScenario.Cofe, this.StringListCafe_en);

        this.titleDict_de.Add(EScenario.Start, "AR Anleitungs App");
        this.titleDict_de.Add(EScenario.PC, "Tausche die Festplate aus");
        this.titleDict_de.Add(EScenario.Printer, "Tausche den Drucker Toner aus");
        this.titleDict_de.Add(EScenario.Cofe, "Mach dir einen Kaffee");

        this.textDict_de.Add(EScenario.Start, null);
        this.textDict_de.Add(EScenario.PC, this.StringListPC_de);
        this.textDict_de.Add(EScenario.Printer, this.StringListPrinter_de);
        this.textDict_de.Add(EScenario.Cofe, this.StringListCafe_de);

        this.animationDict.Add(EScenario.Start, null);
        this.animationDict.Add(EScenario.PC, this.animationsPC);
        this.animationDict.Add(EScenario.Printer, this.animationsPrinter);
        this.animationDict.Add(EScenario.Cofe, this.animationsCofe);

        this.voiceDict_en.Add(EScenario.Start, null);
        this.voiceDict_en.Add(EScenario.PC, this.voicePC_en);
        this.voiceDict_en.Add(EScenario.Printer, this.voicePrinter_en);
        this.voiceDict_en.Add(EScenario.Cofe, this.voiceCofe_en);

        this.voiceDict_de.Add(EScenario.Start, null);
        this.voiceDict_de.Add(EScenario.PC, this.voicePC_de);
        this.voiceDict_de.Add(EScenario.Printer, this.voicePrinter_de);
        this.voiceDict_de.Add(EScenario.Cofe, this.voiceCofe_de);

        this.buttonBack.SetActive(false);
        this.buttonNext.SetActive(false);
        this.buttonHideVirtualModel.SetActive(false);

        this.ChangeAudios();

        string fileName = "logFile_ARGuiding.txt";

        if (!File.Exists(fileName))
        {
            this.myWriter = File.CreateText(fileName);
        }
        else
        {
            this.myWriter = File.AppendText(fileName);
        }

        myWriter.WriteLine("\n\nNew Application Start: {0}, {1:G}\n", DateTime.Now.ToString("de-DE"), DateTime.Now.Kind);
    }

    #region Getter

    public int getCurrentCount()
    {
        int counter = 0;
        for (int i = 0; i < this.sectionCounter; i++)
        {
            if (i + 1 < this.sectionCounter)
            {
                counter += this.textDict_en[this.currentScenario][i].Count;
            }
            else
            {
                counter += this.taskCounter;
            }
        }

        return counter;
    }
    public int getTaskCounter()
    {
        return this.taskCounter;
    }
    public void setTaskCounter(int taskCounter)
    {
        this.taskCounter = taskCounter;
    }
    public int getSectionCounter()
    {
        return this.sectionCounter;
    }

    public void setSectionCounter(int sectionCounter)
    {
        this.sectionCounter = sectionCounter;
    }
    public List<string>[] getActiveList()
    {
        return this.activeList;
    }
    public List<string>[] getPCList()
    {
        return this.StringListPC_en;
    }
    public List<string>[] getPrinterList()
    {
        return this.StringListPrinter_en;
    }
    public List<string>[] getCafeList()
    {
        return this.StringListCafe_en;
    }
    public string[] getSubtitleList()
    {
        return this.subtitleList_en;
    }

    #endregion
}
