using UnityEngine;
using UnityEngine.UI;

public class MusicButton : MonoBehaviour
{
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.interactable = false;
        gameObject.SetActive(false);

    }

    
}
