using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI promtText;
    [SerializeField]
    private Image crosshairDefault;
    [SerializeField]
    private Image crosshairInteract;

    void Start()
    {
        
    }

    public void UpdateText(string promtMessage)
    {
        promtText.text = promtMessage;
    }

    public void UpdateCrosshair(bool interactable)
    {
        if (interactable)
        {
            crosshairDefault.enabled = false;
            crosshairInteract.enabled = true;
        }
        else
        {
            crosshairDefault.enabled = true;
            crosshairInteract.enabled = false;
        }
    }
}
