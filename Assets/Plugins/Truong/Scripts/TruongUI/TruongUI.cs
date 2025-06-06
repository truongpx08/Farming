using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class TruongUI : TruongGameObject
{
    public void AddActionToButton(Button button, UnityAction action)
    {
        button.onClick.AddListener(action);
    }

    public void AddActionToButton(UnityAction action, Button button)
    {
        button.onClick.AddListener(action);
    }

    protected void SetTextMeshProUGUI(TextMeshProUGUI textMeshProUGUI, string value)
    {
        textMeshProUGUI.text = value;
    }
}