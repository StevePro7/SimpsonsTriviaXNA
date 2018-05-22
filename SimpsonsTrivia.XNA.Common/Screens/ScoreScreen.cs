using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class ScoreScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
			LoadTextData();
		}

		public override void LoadContent()
		{
		}

		public ScreenType Update(GameTime gameTime)
		{
			UpdateVolumeIcon();

			Boolean escape = MyGame.Manager.InputManager.Escape();
			if (escape)
			{
				return ScreenType.Exit;
			}
			Boolean left = MyGame.Manager.InputManager.LeftArrow();
			if (left)
			{
				return ScreenType.Over;
			}
			Boolean rght = MyGame.Manager.InputManager.RghtArrow();
			if (rght)
			{
				return ScreenType.Play;
			}

			return ScreenType.Score;
		}

		public override void Draw()
		{
			MyGame.Manager.TextManager.Draw(TextDataList);

			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			MyGame.Manager.SoundManager.DrawVolumeIcon();

			MyGame.Manager.DeviceManager.DrawOverButton();
			MyGame.Manager.DeviceManager.DrawQuizButton();

			Engine.Game.Window.Title = "Score";
		}

	}
}