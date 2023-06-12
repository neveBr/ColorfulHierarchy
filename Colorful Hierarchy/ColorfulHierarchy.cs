using UnityEngine;

namespace ColorfulHierarchy
{
    public class ColorfulHierarchy : MonoBehaviour
    {
        public static readonly Color DEFAULT_BACKGROUND_COLOR = new Color(0.2196079f, 0.2196079f, 0.2196079f, 1f);
        public static readonly Color DEFAULT_TEXT_COLOR = new Color(0.8f, 0.8f, 0.8f, 1f);

        public ColorfulHierarchy() { }
        public ColorfulHierarchy(Color inBackgroundColor)
        {
            this.Background_Color = inBackgroundColor;
        }

        public ColorfulHierarchy(Color inBackgroundColor, Color inTextColor, FontStyle inFontStyle = FontStyle.Normal)
        {
            this.Background_Color = inBackgroundColor;
            this.Text_Color = inTextColor;
            this.TextStyle = inFontStyle;
        }

        [ContextMenuItem("Reset Text color", "ResetTXTColor")]
        public Color Text_Color = DEFAULT_TEXT_COLOR;
        public FontStyle TextStyle = FontStyle.Normal;
        [ContextMenuItem("Reset BG color", "ResetBGColor")]
        public Color Background_Color = DEFAULT_BACKGROUND_COLOR;

        public void ResetBGColor() { Background_Color = DEFAULT_BACKGROUND_COLOR; }
        public void ResetTXTColor() { Text_Color = DEFAULT_TEXT_COLOR; ; }


    }
}