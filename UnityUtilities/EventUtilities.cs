using UnityEngine;
using UnityEditor;
namespace Lasm.UnityUtilities
{
    public static class EventUtilities
    {
        private static float lastClickTime = 0f;
        private static int clickCount = 0;

#if UNITY_EDITOR
        public static bool isDoubleClickedInEditor(float elapseTime)
        {
            Event e = Event.current;

            if (e.isMouse && e.type == EventType.MouseDown && e.clickCount == 2)
            {
                return true;
            }
            return false;
        }
#endif

        public static bool isDoubleClicked(float elapseTime)
        {

            if ((lastClickTime - Time.time) * -1 < elapseTime)
            {
                lastClickTime = Time.time;
                return true;
            }

            lastClickTime = Time.time;
            return false;
        }
    }
}
