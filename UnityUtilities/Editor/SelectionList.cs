using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Lasm.OdinSerializer;

namespace Lasm.UnityEditorUtilities
{
    [Serializable]
    public class SelectionList<TType> where TType : class
    {
        [OdinSerialize] public List<StaticSelection<TType>> items { get; private set; }
        [OdinSerialize] public Vector2 scrollPosition;
        [OdinSerialize] public StaticSelection<TType> selection = null;

        public void Draw(GUIStyle backgroundStyle)
        {
            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginHorizontal(backgroundStyle);

            EditorGUILayout.BeginVertical();

            EditorGUILayout.BeginVertical(backgroundStyle);

            scrollPosition = GUILayout.BeginScrollView(scrollPosition, backgroundStyle, GUILayout.MaxHeight(300));

            for (int i = 0; i < items.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();

                var styleContent = new SelectionStyleContent();
                styleContent.borderThickness = 2;
                styleContent.pressed = new Color(0.6f, 0.6f, 0.6f);
                styleContent.active = new Color(0.7f, 0.7f, 0.7f);
                styleContent.background = Color.grey;
                styleContent.border = Color.black;
                styleContent.height = 20;
                styleContent.text = items[i].name;

                if (items[i] != null)
                items[i].Draw(styleContent);
                
                var textStyle = new GUIStyle(EditorStyles.whiteBoldLabel);
                textStyle.alignment = TextAnchor.MiddleCenter;
                textStyle.fontSize = 12;
                GUI.Label(GUILayoutUtility.GetLastRect(), styleContent.text, textStyle);

                EditorGUILayout.EndHorizontal();
            }

            GUILayout.EndScrollView();

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();
        }

        public void AddItem(StaticSelection<TType> selection)
        {
            items.Add(selection);
        }

        public void RemoveItem(int index)
        {
            items.RemoveAt(index);
        }

        public void RemoveItem(StaticSelection<TType> selection)
        {
            items.Remove(selection);
        }

        public bool HasItem(StaticSelection<TType> selection)
        {
            return items.Contains(selection);
        }

        public bool HasItem(int index)
        {
            return items[index] != null;
        }

        public void Override (List<StaticSelection<TType>> otherList)
        {
            items = otherList;
        }
    }
}

