using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class OverScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
			LoadTextData();
		}

		public override void LoadContent()
		{
			MyGame.Manager.SoundManager.PlayGameOver();
		}

		public ScreenType Update(GameTime gameTime)
		{
			Boolean volume = MyGame.Manager.InputManager.VolumeIcon();
			if (volume)
			{
				MyGame.Manager.SoundManager.AlternateSound();
			}

			Boolean left = MyGame.Manager.InputManager.LeftArrow();
			if (left)
			{
				Engine.Game.Exit();
			}
			Boolean rght = MyGame.Manager.InputManager.RghtArrow();
			if (rght)
			{
				MyGame.Manager.SoundManager.StopMusic();
				return ScreenType.Title;
			}

			return ScreenType.Over;
		}

		//public override void Draw()
		//{
		//	MyGame.Manager.ImageManager.DrawHeader();
		//	MyGame.Manager.ImageManager.DrawCurrActor();

		//	////MyGame.Manager.ImageManager.DrawHeader();
		//	////MyGame.Manager.ImageManager.DrawTitle();
		//	////byte index = MyGame.Manager.ConfigManager.GlobalConfigData.ActorIndex;
		//	////MyGame.Manager.ImageManager.DrawActor(index);

		//	//MyGame.Manager.TextManager.Draw(TextDataList);
		//	//Engine.Game.Window.Title = "Over";
		////}

		public override void Draw()
		{
			MyGame.Manager.TextManager.Draw(TextDataList);

			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			MyGame.Manager.SoundManager.DrawVolumeIcon();

			MyGame.Manager.DeviceManager.DrawOverButton();
			MyGame.Manager.DeviceManager.DrawPlayButton();

			Engine.Game.Window.Title = "Over";
		}

	}
}