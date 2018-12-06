using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Localization/LanguageDict")]
public class LanguageDict : ScriptableObject {
    public List<LanguageStuff> Languages = new List<LanguageStuff>();
    public int langKey;

    public string[] getLanguages(){
        string[] arr = new string[Languages.Count];
        for (int i = 0; i < Languages.Count; i++){
            arr[i] = Languages[i].Language;
        }
        return arr;
    }
}

[Serializable]
public class LanguageStuff{
    public string Language;
    public List<DictItems> keyAndValue = new List<DictItems>();

    public string GetValue(int key){
        return keyAndValue[key].value;
    }

    public string[] getKeys(){
        string[] arr = new string[keyAndValue.Count];
        for (int i = 0; i < keyAndValue.Count; i++)
        {
            arr[i] = keyAndValue[i].key;
        }
        return arr;
    }
}

[Serializable]
public class DictItems{
    public string key;
    public string value;
}
