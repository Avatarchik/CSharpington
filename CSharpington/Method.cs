using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Lasm.OdinSerializer;

namespace Lasm.CSharpington
{
    [Serializable]
    public class Method 
    {
        [OdinSerialize]
        public string name;
    }
}
