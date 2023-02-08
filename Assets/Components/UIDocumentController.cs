using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class UIDocumentController : MonoBehaviour
{
    public static readonly string MainMenuAssetName = "MainMenu";
    public static readonly string SettingsScreenAssetName = "SettingsScreen";

    string currentlySelectedScreen = MainMenuAssetName;

    void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        Button playButton = uiDocument.rootVisualElement.Q("PlayButton") as Button;
        playButton.RegisterCallback<ClickEvent>(Play);
        Button exitButton = uiDocument.rootVisualElement.Q("ExitButton") as Button;
        exitButton.RegisterCallback<ClickEvent>(ExitApplication);
        Button settingsButton = uiDocument.rootVisualElement.Q("SettingsButton") as Button;
        settingsButton.RegisterCallback<ClickEvent>(OpenSettings);
    }

    void Update ()
    {
        if (Input.GetKeyDown("escape")) {
            if (currentlySelectedScreen == null || currentlySelectedScreen == SettingsScreenAssetName) {
                OpenScreen(MainMenuAssetName);
                OnEnable();
            }
            else if (currentlySelectedScreen == MainMenuAssetName)
            {
                Application.Quit();
            }
        }
    }

    void OpenScreen (string assetName) {
        currentlySelectedScreen = assetName;
        GameObject.FindFirstObjectByType<UnityEngine.UIElements.UIDocument>().visualTreeAsset = Resources.Load<VisualTreeAsset>(assetName);
    }

    void Play (ClickEvent clickEvent)
    {
        OpenScreen(null);
    }

    void OpenSettings (ClickEvent clickEvent)
    {
        OpenScreen(SettingsScreenAssetName);
    }

    void ExitApplication (ClickEvent clickEvent)
    {
        Application.Quit();
    }
}
