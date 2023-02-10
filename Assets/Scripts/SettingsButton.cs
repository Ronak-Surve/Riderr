using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    public Button musicButton;
    public Button soundButton;  
    public Button playButton;
    public Button settingsButton;
    public Button creditButton;



    public void OnClick()
    {
        musicButton.gameObject.SetActive(true);
        soundButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        creditButton.gameObject.SetActive(false);
    }
}
