using System.Linq;
using UnityEngine;
using UnityEditor;

namespace ColorfulHierarchy
{
    [InitializeOnLoad]
    public class ColorfulHierarchyManager
    {
        public static readonly Color DEFAULT_COLOR_HIERARCHY_SELECTED = new Color(0.243f, 0.4901f, 0.9058f, 1f);
        static ColorfulHierarchyManager()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= HierarchyHighlight_OnGUI;
            EditorApplication.hierarchyWindowItemOnGUI += HierarchyHighlight_OnGUI;
        }

        private static void HierarchyHighlight_OnGUI(int inSelectionID, Rect inSelectionRect)
        {
            GameObject GO_Label = EditorUtility.InstanceIDToObject(inSelectionID) as GameObject;

            if (GO_Label != null)
            {
                ColorfulHierarchy Label = GO_Label.GetComponent<ColorfulHierarchy>();

                if (Label != null && Event.current.type == EventType.Repaint)
                {
                    #region Style
                    bool ObjectIsSelected = Selection.instanceIDs.Contains(inSelectionID);
                    Color BKCol = Label.Background_Color;
                    Color TextCol = Label.Text_Color;
                    FontStyle TextStyle = Label.TextStyle;

                    if (!Label.isActiveAndEnabled)
                    {
                        if (BKCol != ColorfulHierarchy.DEFAULT_BACKGROUND_COLOR) // Reduce opacity 
                            BKCol.a = BKCol.a * 0.5f;
                        TextCol.a = TextCol.a * 0.5f;
                    }
                    #endregion
                    Rect Offset = new Rect(inSelectionRect.position + new Vector2(2f, 0f), inSelectionRect.size);


                    #region Background
                    if (BKCol.a > 0f)
                    {
                        Rect BackgroundOffset = new Rect(inSelectionRect.position, inSelectionRect.size);
                        if (Label.Background_Color.a < 1f || ObjectIsSelected)
                        {
                            EditorGUI.DrawRect(BackgroundOffset, ColorfulHierarchy.DEFAULT_BACKGROUND_COLOR);
                        }
                        if (ObjectIsSelected)
                            EditorGUI.DrawRect(BackgroundOffset, Color.Lerp(GUI.skin.settings.selectionColor, BKCol, 0.3f));
                        else
                            EditorGUI.DrawRect(BackgroundOffset, BKCol);
                    }
                    #endregion
                    EditorGUI.LabelField(Offset, GO_Label.name, new GUIStyle()
                    {
                        normal = new GUIStyleState() { textColor = TextCol },
                        fontStyle = TextStyle
                    });
                    EditorApplication.RepaintHierarchyWindow();
                }
            }
        }
    }
}