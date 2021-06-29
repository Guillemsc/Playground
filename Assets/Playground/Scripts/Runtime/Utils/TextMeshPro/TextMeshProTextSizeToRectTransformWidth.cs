using UnityEngine;

namespace Playground.Utils.TextMeshPro
{
    [ExecuteInEditMode]
    public class TextMeshProTextSizeToRectTransformWidth : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI textMeshPro = default;
        [SerializeField] private RectTransform rectTransform = default;

        private void Update()
        {
            CopyWidthToRectTransform();
        }

        private void CopyWidthToRectTransform()
        {
            if(textMeshPro == null)
            {
                return;
            }

            if (rectTransform == null)
            {
                return;
            }

            rectTransform.sizeDelta = new Vector2(textMeshPro.bounds.size.x, rectTransform.sizeDelta.y);
        }
    }
}
