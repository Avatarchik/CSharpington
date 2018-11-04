using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lasm.CSharpington {
    public abstract class ClassExportScript : ExportScript
    {
        public virtual string References() { return string.Empty; }
        public virtual string Class() { return string.Empty; }
        public virtual string Fields() { return string.Empty; }
        public virtual string Properties() { return string.Empty; }
        public virtual string Constructors() { return string.Empty; }
        public virtual string Methods() { return string.Empty; }
        public virtual string Events() { return string.Empty; }
        public virtual string Indexers() { return string.Empty; }
    }
}
