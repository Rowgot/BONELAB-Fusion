#if MELONLOADER
using Il2CppInterop.Runtime.Attributes;

using MelonLoader;
#endif

using UnityEngine;

namespace LabFusion.Marrow.Proxies
{
#if MELONLOADER
    [RegisterTypeInIl2Cpp]
#endif
    public class GroupElement : LabelElement
    {
#if MELONLOADER
        public GroupElement(IntPtr intPtr) : base(intPtr) { }

        public List<MenuElement> Elements => _elements;

        public List<MenuElement> Templates => _elementTemplates;

        private readonly List<MenuElement> _elements = new();
        private readonly List<MenuElement> _elementTemplates = new();

        private bool _hasTemplates = false;

        protected override void Awake()
        {
            base.Awake();

            GetTemplates();
        }

        private void GetTemplates()
        {
            if (_hasTemplates)
            {
                return;
            }

            foreach (var child in transform)
            {
                var childTransform = child.TryCast<Transform>();

                var childTemplate = childTransform.GetComponent<MenuElement>();

                if (childTemplate != null)
                {
                    _elementTemplates.Add(childTemplate);
                }
            }

            _hasTemplates = true;
        }

        [HideFromIl2Cpp]
        protected virtual void OnElementAdded(MenuElement element) 
        {
            element.gameObject.SetActive(true);
        }

        [HideFromIl2Cpp]
        public TElement AddElement<TElement>(string title) where TElement : MenuElement
        {
            GetTemplates();

            TElement template = null;

            foreach (var found in _elementTemplates)
            {
                var casted = found.TryCast<TElement>();

                if (casted != null)
                {
                    template = casted;
                    break;
                }
            }

            if (template == null)
            {
                return null;
            }

            var newElement = GameObject.Instantiate(template, transform, false);
            newElement.name = title;
            newElement.Title = title;

            _elements.Add(newElement);

            OnElementAdded(newElement);

            return newElement;
        }
#endif
    }
}