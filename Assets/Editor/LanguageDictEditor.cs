using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LanguageDict))]
public class LanguageDictEditor : Editor {

    private LanguageDict languageDict;
    private SerializedObject languageDictSO;

    private LanguageStuff languageStuff;
    private SerializedObject languageStuffSO;
    private SerializedProperty languageStuffSP;

    private DictItems keyAndVal;
    private SerializedObject keyAndValSO;
    private SerializedProperty keyAndValSP;

    private SerializedProperty cnt;
    private string langName;
    private string newKey;
    private string newVal;
    private static string listSize = "Languages.Array.size";
    private static string listData = "Languages.Array.data[{0}]";

    public void OnEnable()
    {
        languageDict = (LanguageDict)target;
        languageDictSO = new SerializedObject(languageDict);
        languageStuffSP = languageDictSO.FindProperty("Languages");
        cnt = languageDictSO.FindProperty(listSize);
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        languageDictSO.Update();

        langName = EditorGUILayout.TextField("Language Name",langName);

        if(GUILayout.Button("Add Language")){
            LanguageStuff newLang = new LanguageStuff();
            newLang.Language = langName;
            languageDict.Languages.Add(newLang);
        }

        if (cnt.intValue == 0)
        {
            EditorGUILayout.LabelField("No Current Languages");
        }
        else
        {
            for (int i = 0; i < cnt.intValue; i++)
            {
                if(languageDict.Languages[i] != null){
                    EditorGUILayout.LabelField(languageDict.Languages[i].Language);
                    EditorGUILayout.LabelField("Key and Values");
                    for (int k = 0; k < languageDict.Languages[i].keyAndValue.Count; k++){
                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.LabelField(languageDict.Languages[i].keyAndValue[k].key);
                        languageDict.Languages[i].keyAndValue[k].value = EditorGUILayout.TextField(languageDict.Languages[i].keyAndValue[k].value);
                        if (GUILayout.Button("Del"))
                        {
                            List<DictItems> copyKey = new List<DictItems>();
                            // languageDict.language
                            for (int j = 0; j < languageDict.Languages[i].keyAndValue.Count; j++)
                            {
                                //languageDict.Languages[j] = languageDict.Languages[j + 1];
                                if (j != k)
                                {
                                    copyKey.Add(languageDict.Languages[i].keyAndValue[j]);
                                }
                            }
                            languageDict.Languages[i].keyAndValue = copyKey;
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                    newKey = EditorGUILayout.TextField("Key", newKey);
                    newVal = EditorGUILayout.TextField("Value", newVal);
                    if (GUILayout.Button("Add Key and Value")){
                        DictItems newDict = new DictItems();
                        newDict.key = newKey;
                        newDict.value = newVal;
                        languageDict.Languages[i].keyAndValue.Add(newDict);
                    }

                    if (GUILayout.Button("Delete Language"))
                    {
                        List<LanguageStuff> copy = new List<LanguageStuff>();
                        // languageDict.language
                        for (int j = 0; j < languageDict.Languages.Count; j++){
                            //languageDict.Languages[j] = languageDict.Languages[j + 1];
                            if(j != i){
                                copy.Add(languageDict.Languages[j]);
                            }
                        }
                        languageDict.Languages = copy;
                    }
                }
            }
        }


        languageDictSO.ApplyModifiedProperties();
    }
}
