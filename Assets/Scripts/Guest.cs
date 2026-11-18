using UnityEngine;

public class Guest : MonoBehaviour {
    public GuestData data;
    SpriteRenderer bodySprite;
    void Start() {
        bodySprite = GetComponentInChildren<SpriteRenderer>();
        RefreshUI();
    }
    public void RefreshUI() {
        bodySprite.sprite = data.spriteMain;
    }
}