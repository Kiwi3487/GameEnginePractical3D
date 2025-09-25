using System;
using TMPro;
using UnityEngine;

public class TextReader : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private string filePath;
    private int currentLineIndex = 0;

    private void Start()
    {
        filePath = Application.dataPath + "/";
    }
}
