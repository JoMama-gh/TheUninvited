


using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem; 

public class GameManager : MonoBehaviour, IDragHandler {
    public void OnDrag(PointerEventData eventData) {
        // Haetaan hiiren/sormen sijainti uudella Input Systemillä
        if (Pointer.current != null) {
            Vector2 mousePos = Pointer.current.position.ReadValue();
            transform.position = mousePos;
        }
    }
}
