using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC4 : MonoBehaviour
{
    public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		
		FindObjectOfType<DialogueManagerNPC4>().StartDialogue(dialogue);
	}
}
