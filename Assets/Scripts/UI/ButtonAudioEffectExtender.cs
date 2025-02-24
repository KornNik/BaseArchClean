using Behaviours;
using UnityEngine;

namespace UI
{
    class ButtonAudioEffectExtender : ButtonEffectExtender
    {
        [SerializeField] private AudioClip _clickClip;

        protected override void CustomButtonEffect()
        {
            MakeSoundEvent.Trigger(new SoundEventInfo(_clickClip, Vector3.zero));
        }
    }
}
