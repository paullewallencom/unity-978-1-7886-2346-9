using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class GameAudioController
	{
		// initial audio levels for background and
		// sound FX
		public float AudioLevel = 0.33f;
		public float FxAudioLevel = 0.33f;

		public AudioSource audioSource;

		public void SetDefaultVolume()
		{
			audioSource.volume = AudioLevel;
		}

		public void MasterVolume(float volume)
		{
			AudioLevel = volume;
			audioSource.volume = AudioLevel;
		}

		public void SoundFxVolume(float volume)
		{
			FxAudioLevel = volume;
		}
	}
}