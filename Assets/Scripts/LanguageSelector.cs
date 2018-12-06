using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LanguageSelector : MonoBehaviour {

    public LanguageDict languageDict;
    [NonSerialized] public int langKey;
    [NonSerialized] public int textKey;
    [NonSerialized] public Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(languageDict.Languages == null)
        {
            text.text = " ";
        }
        else if(languageDict.Languages.Count == 0 || languageDict.Languages.Count - 1 < languageDict.langKey){
            text.text = " ";
        }
        else if(languageDict.Languages[languageDict.langKey].keyAndValue.Count - 1 < textKey)
        {
            text.text = " ";
        }
        else{
            if (languageDict.Languages[languageDict.langKey] != null && languageDict.Languages[languageDict.langKey].keyAndValue[textKey] != null)
            {
                text.text = languageDict.Languages[languageDict.langKey].GetValue(textKey);
            }
        }
	}
}
