using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using System.Threading.Tasks;

namespace Lasm.CSharpington
{
    public abstract class ExportScript
    {
        public abstract string MakeScriptString();
        private bool isRefreshable = false;

        public void Save(string path)
        {
            try
            {
                using (FileStream fileStream = File.Open(path, FileMode.OpenOrCreate))
                {
                    using (StreamWriter stream = new StreamWriter(fileStream))
                    {
                        stream.Write(MakeScriptString());
                    }
                }

#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif
            }
            catch (Exception e)
            {
                Debug.LogError("Exception: " + e);
            }
        }
    }
}
