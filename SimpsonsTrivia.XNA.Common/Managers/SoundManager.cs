using System;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using WindowsGame.Common.Static;
using MediaPlayerX = Microsoft.Xna.Framework.Media.MediaPlayer;

namespace WindowsGame.Common.Managers
{
	public interface ISoundManager
	{
		void Initialize();

		void PlayTitleMusic();
		void PlayGameOver();
		void StopMusic();
		void PauseMusic();
		void ResumeMusic();

		void PlayRightSoundEffect();
		void PlayWrongSoundEffect();
		void PlayCheatSoundEffect();
		void PlayEarlySoundEffect();

		void AlternateSound();
		void DrawVolumeIcon();
	}

	public class SoundManager : ISoundManager
	{
		private Boolean playSound;

		public void Initialize()
		{
			playSound = MyGame.Manager.ConfigManager.GlobalConfigData.PlaySound;
		}

		public void PlayTitleMusic()
		{
			PlaySong(Assets.TitleMusicSong, false);
		}

		public void PlayGameOver()
		{
			PlaySong(Assets.GameOverSong, false);
		}

		public void StopMusic()
		{
			if (MediaState.Playing == MediaPlayerX.State)
			{
				MediaPlayerX.Stop();
			}
		}

		public void PauseMusic()
		{
			if (MediaState.Playing == MediaPlayerX.State)
			{
				MediaPlayerX.Pause();
			}
		}

		public void ResumeMusic()
		{
			if (MediaState.Paused == MediaPlayerX.State)
			{
				MediaPlayerX.Resume();
			}
		}

		public void PlayRightSoundEffect()
		{
			PlaySoundEffect(SoundEffectType.Right);
		}
		public void PlayWrongSoundEffect()
		{
			PlaySoundEffect(SoundEffectType.Wrong);
		}
		public void PlayCheatSoundEffect()
		{
			PlaySoundEffect(SoundEffectType.Cheat);
		}
		public void PlayEarlySoundEffect()
		{
			PlaySoundEffect(SoundEffectType.Early);
		}

		public void AlternateSound()
		{
			playSound = !playSound;
			SetVolume();
		}

		public void DrawVolumeIcon()
		{
			if (playSound)
			{
				MyGame.Manager.SpriteManager.DrawVolumeOn();
			}
			else
			{
				MyGame.Manager.SpriteManager.DrawVolumeOff();
			}
		}

		private void PlaySong(Song song, Boolean isRepeating)
		{
			//if (!playSound)
			//{
			//	return;
			//}

			if (MediaState.Playing == MediaPlayerX.State)
			{
				return;
			}
			SetVolume();

			MediaPlayerX.Play(song);
			MediaPlayerX.IsRepeating = isRepeating;
		}
		private void PlaySoundEffect(SoundEffectType key)
		{
			if (!playSound)
			{
				return;
			}

			SoundEffectInstance value = Assets.SoundEffectDictionary[key];
			value.Play();
		}
		private void SetVolume()
		{
			MediaPlayerX.Volume = playSound ? 100 : 0;
		}

	}
}