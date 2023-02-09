using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class UIDocumentController : MonoBehaviour
{
    private static readonly string MainMenuAssetName = "MainMenu";
    private static readonly string SettingsScreenAssetName = "SettingsScreen";

    private UIDocument uiDocument;
    private string currentlySelectedScreen;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        OpenMainMenu(null);
    }

    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (currentlySelectedScreen == SettingsScreenAssetName) {
                OpenMainMenu(null);
            }
            else if (currentlySelectedScreen == MainMenuAssetName)
            {
                Application.Quit();
            }
        }
    }

    void OpenScreen(string assetName) {
        currentlySelectedScreen = assetName;
        uiDocument.visualTreeAsset = Resources.Load<VisualTreeAsset>(assetName);
    }

    void Play(ClickEvent clickEvent)
    {
        SceneManager.LoadScene("1");
    }

    void OpenMainMenu(ClickEvent clickEvent) {
        OpenScreen(MainMenuAssetName);
        Button playButton = uiDocument.rootVisualElement.Q("PlayButton") as Button;
        playButton.RegisterCallback<ClickEvent>(Play);
        Button exitButton = uiDocument.rootVisualElement.Q("ExitButton") as Button;
        exitButton.RegisterCallback<ClickEvent>(ExitApplication);
        Button settingsButton = uiDocument.rootVisualElement.Q("SettingsButton") as Button;
        settingsButton.RegisterCallback<ClickEvent>(OpenSettings);
    }

    void OpenSettings(ClickEvent clickEvent)
    {
        OpenScreen(SettingsScreenAssetName);
        Button settingsButton = uiDocument.rootVisualElement.Q("BackButton") as Button;
        settingsButton.RegisterCallback<ClickEvent>(OpenMainMenu);
    }

    void ExitApplication(ClickEvent clickEvent)
    {
        Application.Quit();
    }
}
