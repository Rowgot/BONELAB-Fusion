#if MELONLOADER
using Il2CppTMPro;
using MelonLoader;
using UnityEngine;
#endif

namespace LabFusion.Marrow.Proxies
{
#if MELONLOADER
    [RegisterTypeInIl2Cpp]
#endif
    public class LabelElement : MenuElement
    {
#if MELONLOADER
        public LabelElement(IntPtr intPtr) : base(intPtr) { }

        private Color _color = Color.white;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;

                Draw();
            }
        }

        public TMP_Text Text { get { return _text; } set { _text = value; } }

        private TMP_Text _text = null;

        protected virtual void Awake()
        {
            var textTransform = transform.Find("text");

            if (textTransform != null)
            {
                _text = textTransform.GetComponent<TMP_Text>();
            }
        }

        protected override void OnDraw()
        {
            base.OnDraw();

            UpdateText();
        }

        public virtual void UpdateText()
        {
            if (Text != null)
            {
                Text.text = Title;
                Text.color = Color;
            }
        }
#endif
    }
}