using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChangeLanguage : MonoBehaviour
{
    public List<AudioSource> englishVoice;
    public List<AudioSource> germanVoice;


    private bool isEnglishLanguage = true;
    private bool modeChanged = false;

    /// <summary>
    /// This method is triggered when the language button is clicked.
    /// It changes the state of the private isEnglishLanguage variable.
    /// </summary>
    public void LanguageChanged()
    {
        if (this.isEnglishLanguage)
        {
            this.isEnglishLanguage = false;
            this.modeChanged = true;
        }
        else
        {
            this.isEnglishLanguage = true;
            this.modeChanged = true;
        }
    }

    /// <summary>
    /// This method is called every frame. It activates the needed langauge if the mode was changed. 
    /// </summary>
    public void Update()
    {
        if (this.modeChanged)
        {
            this.modeChanged = false;
            if (this.isEnglishLanguage) // English language set
            {
                foreach (AudioSource audio in this.englishVoice)
                {
                    audio.gameObject.SetActive(true);
                }
                foreach (AudioSource audio in this.germanVoice)
                {
                    audio.gameObject.SetActive(false);
                }
            }
            else // German language set
            {
                foreach (AudioSource audio in this.englishVoice)
                {
                    audio.gameObject.SetActive(false);
                }
                foreach (AudioSource audio in this.germanVoice)
                {
                    audio.gameObject.SetActive(true);
                }
            }
        }
    }

    public bool getIsEnglishLanguage()
    {
        return this.isEnglishLanguage;
    }
    public bool getModeChanged()
    {
        return this.modeChanged;
    }
}