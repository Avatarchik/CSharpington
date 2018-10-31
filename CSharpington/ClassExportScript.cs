using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.CSharpington {
    public abstract class ClassExportScript : ExportScript
    { 
        public abstract string Reference();
        public abstract string Class();
        public abstract string Fields();
        public abstract string Properties();
        public abstract string Constructors();
        public abstract string Methods();
    }
}
