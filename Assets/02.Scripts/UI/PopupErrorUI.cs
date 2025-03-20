using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupErrorUI : MonoBehaviour
{
    public TextMeshProUGUI errorText;
    public Button confirmBtn;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        confirmBtn?.onClick.AddListener(OnConfirmBtn);
    }

    private void OnDisable()
    {
        confirmBtn?.onClick.RemoveListener(OnConfirmBtn);
    }

    public void SetErrorText(string text)
    {
        errorText.text = text;
        gameObject.SetActive(true);
    }

    public void OnConfirmBtn()
    {
        SetErrorText("");
        gameObject.SetActive(false);
    }
}
