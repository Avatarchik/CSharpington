using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Lasm.OdinSerializer;

namespace Lasm.UnityEditorUtilities
{
    [Serializable]
    public class StaticSelection<TType> where TType : class
    {
        [OdinSerialize]
        public string name = string.Empty;
        [OdinSerialize]
        public object @object = null;
        [OdinSerialize]
        public SelectionList<TType> owner { get; private set; }
        [OdinSerialize]
        public bool isActiveSelection = false;
        [OdinSerialize]
        public Action<TType> onSelected = null;

        public bool isPressed = false;

        public StaticSelection(string name, TType @object)
        {
            this.name = name;
            this.@object = @object;
        }

        public StaticSelection(string name, TType @object, Action<TType> onSelected)
        {
            this.name = name;
            this.@object = @object;
            this.onSelected = onSelected;
        }

        public void Draw(SelectionStyleContent content)
        {
            var activeSelection = isActiveSelection;
            UtilityGUILayout.BorderedRectButton(content, ref isActiveSelection, ref isPressed);
            if (!activeSelection) if (isActiveSelection) activeSelection = true;
            
            if (activeSelection && onSelected != null) onSelected((TType)@object);

        }
    }
}