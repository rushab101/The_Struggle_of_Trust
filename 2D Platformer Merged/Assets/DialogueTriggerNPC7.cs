using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC7 : MonoBehaviour
{
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC7>().StartDialogue(dialogue);
	}
}
