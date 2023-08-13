using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.InventorySystem
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IDropHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        
        private Canvas _canvas;
        private SlotView _slotView;
        

        public void Init(Canvas canvas, SlotView slotView)
        {
            _slotView = slotView;
            _canvas = canvas;
        }
       
        public void OnBeginDrag(PointerEventData eventData)
        {
            _slotView.HideItemInfo();
            //_slotView.transform.SetAs
        }

        public void OnDrag(PointerEventData eventData)
        {
            MoveItem(eventData);
        }

        public void OnDrop(PointerEventData eventData)
        {
        }

        private void MoveItem(PointerEventData eventData) 
            => _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
    }
}