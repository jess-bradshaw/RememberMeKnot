using UnityEngine;
using Yarn.Unity;

#nullable enable

namespace Yarn.Unity.Addons.SpeechBubbles.Example
{
    public class ConversationTrigger : MonoBehaviour
    {
        [SerializeField] DialogueRunner? dialogueRunner;

        [SerializeField] YarnProject? project;

        [YarnNode(yarnProjectAttribute: nameof(project))]
        [SerializeField] string? nodeName;

        public void StartConversation()
        {
            if (dialogueRunner == null)
            {
                Debug.LogWarning($"Can't start conversation with {name}, because {nameof(dialogueRunner)} is null", this);
                return;
            }

            if (nodeName == null)
            {
                Debug.LogWarning($"Can't start conversation with {name}, because {nameof(nodeName)} is not set", this);
                return;
            }

            if (!dialogueRunner.IsDialogueRunning)
            {
                dialogueRunner.StartDialogue(nodeName);
            }
        }
    }
}