using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LanguageSelector))]
public class LanguageSelectorEditor : Editor {
    private LanguageSelector languageSelector;
    private LanguageDict languageDict;
    private SerializedObject languageSelectorSO;
    private SerializedProperty languageIndex;
    private SerializedProperty keyIndex;

    public void OnEnable()
    {
        languageSelector = (LanguageSelector)target;
        languageSelectorSO = new SerializedObject(languageSelector);
        languageIndex = languageSelectorSO.FindProperty("langKey");
        keyIndex = languageSelectorSO.FindProperty("textKey");
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        languageSelectorSO.Update();

        if(languageSelector.languageDict != null){
            EditorGUILayout.LabelField("Language");
            languageSelector.languageDict.langKey = EditorGUILayout.Popup(languageSelector.languageDict.langKey, languageSelector.languageDict.getLanguages());
            if (languageSelector.textKey != -1){
                EditorGUILayout.LabelField("Key");
                languageSelector.textKey = EditorGUILayout.Popup(languageSelector.textKey, languageSelector.languageDict.Languages[languageSelector.languageDict.langKey].getKeys());
            }
        }
        else{
            EditorGUILayout.LabelField("No Language Dictionaries");
        }

        languageSelectorSO.ApplyModifiedProperties();

    }
}
