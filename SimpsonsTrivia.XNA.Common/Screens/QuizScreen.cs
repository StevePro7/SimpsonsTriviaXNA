using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class QuizScreen : BaseScreen, IScreen
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
			Boolean left = MyGame.Manager.InputManager.LeftArrow();
			if (left)
			{
				MyGame.Manager.SoundManager.PlayWrongSoundEffect();
			}

			Boolean rght = MyGame.Manager.InputManager.RghtArrow();
			if (rght)
			{
				MyGame.Manager.SoundManager.PlayEarlySoundEffect();
			}

			return ScreenType.Quiz;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			MyGame.Manager.SpriteManager.DrawSelect(OptionType.A);
			MyGame.Manager.SpriteManager.DrawRight(OptionType.B);
			MyGame.Manager.SpriteManager.DrawWrong(OptionType.C);
			MyGame.Manager.SpriteManager.DrawSelect(OptionType.D);

			MyGame.Manager.DeviceManager.DrawBackButton();
			MyGame.Manager.DeviceManager.DrawPlayButton();

			MyGame.Manager.TextManager.Draw(TextDataList);
			Engine.Game.Window.Title = "Quiz";
		}

	}
}