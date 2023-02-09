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
        OpenMainMenu();
    }

    void Update()
    {
        if (Input.GetKeyDown("escape")) {
            if (currentlySelectedScreen == SettingsScreenAssetName) {
                OpenMainMenu();
            }
            else if (currentlySelectedScreen == MainMenuAssetName)
            {
                Application.Quit();
            }
        }
    }

    void OpenMainMenu() {
        OpenScreen(MainMenuAssetName);
        ((Button)uiDocument.rootVisualElement.Q("PlayButton")).clicked += () => Play();
        ((Button)uiDocument.rootVisualElement.Q("ExitButton")).clicked += () => ExitApplication();
        ((Button)uiDocument.rootVisualElement.Q("SettingsButton")).clicked += () => OpenSettings();
    }

    void OpenScreen(string assetName) {
        currentlySelectedScreen = assetName;
        uiDocument.visualTreeAsset = Resources.Load<VisualTreeAsset>(assetName);
    }

    void Play()
    {
        SceneManager.LoadScene("1");
    }

    void OpenSettings()
    {
        OpenScreen(SettingsScreenAssetName);
        ((Button)uiDocument.rootVisualElement.Q("BackButton")).clicked += () => OpenMainMenu();
    }

    void ExitApplication()
    {
        Application.Quit();
    }
}
