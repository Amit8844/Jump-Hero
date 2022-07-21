using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class JumpButtonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{

	public void OnPointerDown(PointerEventData data)
	{
		if (PlayerJumpScript.instance != null) 
		{
			PlayerJumpScript.instance.SetPower(true);
		}
	}

	public void OnPointerUp(PointerEventData data)
	{
		if (PlayerJumpScript.instance != null)
		{
			PlayerJumpScript.instance.SetPower(false);
		}
	}


} // JumpButtonScript
