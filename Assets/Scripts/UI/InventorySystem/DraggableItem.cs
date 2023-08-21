using GamePlay.InventorySystem;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.InventorySystem
{
    public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private Image _raycastImage;
        [SerializeField] private TextMeshProUGUI _countText;

        private Canvas _canvas;
        private SlotActor _startSlot;
        private Item _item;


        public void Init(Canvas canvas, SlotActor startSlot)
        {
            _startSlot = startSlot;
            _canvas = canvas;
        }

        public void OnBeginDrag(PointerEventData eventData) 
            => TakeItemFromSlot();

        public void OnDrag(PointerEventData eventData) 
            => MoveItem(eventData);

        public void OnEndDrag(PointerEventData eventData)
        {
            SlotActor raycastedSlot = RaycastSlot(eventData);
            if (raycastedSlot == null || _startSlot == raycastedSlot)
                SetToStartSlot();
            else
                SwapWithSlot(raycastedSlot);

            Destroy(gameObject);
        }


        private void TakeItemFromSlot()
        {
            _item = _startSlot.TakeItem(destroyIcon: false);
            _countText.text = $"x{_item.Count}";
            transform.SetParent(_canvas.transform);
            _raycastImage.raycastTarget = false;
        }

        private void SwapWithSlot(SlotActor endSlot)
        {
            Item endSlotItem = endSlot.TakeItem();
            _startSlot.SetItem(endSlotItem);
            endSlot.SetItem(_item);
        }

        private void SetToStartSlot() 
            => _startSlot.SetItem(_item);

        private void MoveItem(PointerEventData eventData) 
            => _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;

        private static SlotActor RaycastSlot(PointerEventData eventData)
        {
            foreach (GameObject hoveredObject in eventData.hovered)
                if (hoveredObject.TryGetComponent(out SlotView slotView))
                    return slotView.Actor;

            return null;
        }
    }
}