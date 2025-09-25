using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ReadText : MonoBehaviour
{
    public Transform contentWindow;
    public GameObject recallTextObject;

    public void Start()
    {
        string readFromFilePath = Application.streamingAssetsPath + "/text/" +  "WriteChat" + ".txt";

        List<string> fileLines = File.ReadAllLines(readFromFilePath).ToList();

        foreach (string line in fileLines)
        {
            Instantiate(recallTextObject, contentWindow);
            recallTextObject.GetComponent<Text>().text = line;
        }
    }
}