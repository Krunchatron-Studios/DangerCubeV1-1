using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
	public Image thisImage;

	public void OnPointerEnter(PointerEventData eventData) {
		thisImage.material = ShaderManager.shm.glow;
	}
	
	public void OnPointerExit(PointerEventData eventData) {
		thisImage.material = ShaderManager.shm.spriteLit;
	}
}
