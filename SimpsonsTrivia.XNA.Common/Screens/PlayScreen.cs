using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class PlayScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
			MyGame.Manager.Logger.Info("hi");
			LoadTextData();
		}

		public override void LoadContent()
		{
			MyGame.Manager.ImageManager.GenerateNextActor();
		}

		public ScreenType Update(GameTime gameTime)
		{
			Boolean left = MyGame.Manager.InputManager.LeftArrow();
			if (left)
			{
				MyGame.Manager.SoundManager.PlayEarlySoundEffect();
				//MyGame.Manager.Logger.Info("hit!");
			}
			return ScreenType.Play;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			byte index = MyGame.Manager.ConfigManager.GlobalConfigData.ActorIndex;
			//MyGame.Manager.ImageManager.DrawActor(index);


			MyGame.Manager.DeviceManager.DrawPlayButton();
			MyGame.Manager.DeviceManager.DrawQuitButton();

			MyGame.Manager.TextManager.Draw(TextDataList);

			MyGame.Manager.SpriteManager.DrawSelect(OptionType.B);
			//MyGame.Manager.SpriteManager.DrawSelectAll();
			MyGame.Manager.SoundManager.DrawVolumeIcon();

			Engine.Game.Window.Title = "Play";
		}

	}
}