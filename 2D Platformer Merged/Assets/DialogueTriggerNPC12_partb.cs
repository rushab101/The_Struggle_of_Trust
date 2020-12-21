using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerNPC12_partb : MonoBehaviour
{
     public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		FindObjectOfType<DialogueManagerNPC12_partb>().StartDialogue(dialogue);
	}
}
