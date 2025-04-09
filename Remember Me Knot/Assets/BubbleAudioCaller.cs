using UnityEngine;

namespace Yarn.Unity.Addons.SpeechBubbles
{
    public class BubbleAudioCaller : MonoBehaviour
    {
        public BubbleDialogueView dialogueView;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            dialogueView.onTriggerContinue += PlayContinueAudio;
            dialogueView.onTriggerChange += PlayChangeAudio;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayContinueAudio()
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Dialogue, this.transform.position);
        }

        public void PlayChangeAudio()
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.Dialogue, this.transform.position);
        }
    }
}