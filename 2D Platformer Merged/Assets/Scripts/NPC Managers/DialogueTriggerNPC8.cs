using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC8 : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC8>().StartDialogue(dialogue);
	}
}
