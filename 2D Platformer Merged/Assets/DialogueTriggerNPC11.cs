using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC11 : MonoBehaviour
{
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC11>().StartDialogue(dialogue);
	}
}
