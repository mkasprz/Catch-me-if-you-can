using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIDocumentController : MonoBehaviour
{
    void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        Button exitButton = uiDocument.rootVisualElement.Q("ExitButton") as Button;
        exitButton.RegisterCallback<ClickEvent>(ExitApplication);
    }

    void ExitApplication(ClickEvent clickEvent)
    {
        Application.Quit();
    }
}
