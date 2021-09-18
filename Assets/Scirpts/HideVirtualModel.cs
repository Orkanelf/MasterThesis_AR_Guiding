using UnityEngine;
using UnityEngine.UI;

public class HideVirtualModel : MonoBehaviour
{
    public GameObject gameObjectPC;
    public GameObject gameObjectPrinter;
    public GameObject gameObjectCafe;
    public Text title;
    private bool showVirtualModel = true;
    private bool modeChanged = false;

    /// <summary>
    /// This method is triggered when the hide virtual model button is clicked.
    /// It changes the state of the private showVirtualModel variable.
    /// </summary>
    public void HideVirtualModelChanged()
    {
        if (this.showVirtualModel)
        {
            this.showVirtualModel = false;
            this.modeChanged = true;
        }
        else
        {
            this.showVirtualModel = true;
            this.modeChanged = true;
        }
    }

    /// <summary>
    /// This method is called every frame.
    /// </summary>
    public void Update()
    {
        if (this.modeChanged)
        {
            this.modeChanged = false;
            if (!this.showVirtualModel)
            {
                this.gameObjectPC.SetActive(false);
                this.gameObjectPrinter.SetActive(false);
                this.gameObjectCafe.SetActive(false);
            }
            else
            {
                this.gameObjectPC.SetActive(true);
                this.gameObjectPrinter.SetActive(true);
                this.gameObjectCafe.SetActive(true);
            }
        }
    }

    public bool getShowVirtualModel()
    {
        return this.showVirtualModel;
    }
    public bool getModeChanged()
    {
        return this.modeChanged;
    }
}
