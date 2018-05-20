using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class LevelScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
			LoadTextData();
		}

		public override void LoadContent()
		{
			MyGame.Manager.ImageManager.GenerateNextActor();
			MyGame.Manager.QuestionManager.LoadQuestionList(DifficultyType.Easy);
		}

		public ScreenType Update(GameTime gameTime)
		{
			// TODO elevate to the base class
			Boolean volume = MyGame.Manager.InputManager.VolumeIcon();
			if (volume)
			{
				MyGame.Manager.SoundManager.AlternateSound();
			}

			Boolean left = MyGame.Manager.InputManager.LeftArrow();
			if (left)
			{
				MyGame.Manager.SoundManager.PlayWrongSoundEffect();
			}
			Boolean rght = MyGame.Manager.InputManager.RghtArrow();
			if (rght)
			{
				//MyGame.Manager.SoundManager.PlayRightSoundEffect();
				return ScreenType.Over;
			}

			return ScreenType.Level;
		}

		public override void Draw()
		{
			MyGame.Manager.QuestionManager.DrawQuestion(0);
			MyGame.Manager.TextManager.Draw(TextDataList);

			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			MyGame.Manager.SpriteManager.DrawSelectAll();
			MyGame.Manager.SoundManager.DrawVolumeIcon();

			MyGame.Manager.DeviceManager.DrawBackButton();
			MyGame.Manager.DeviceManager.DrawViewButton();

			Engine.Game.Window.Title = "Level";
		}

		//public void DrawX()
		//{
		//    MyGame.Manager.ImageManager.DrawHeader();

		//    byte index = MyGame.Manager.ConfigManager.GlobalConfigData.ActorIndex;
		//    MyGame.Manager.ImageManager.DrawActor(index);

		//    // TODO - fix with offset
		//    //Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 9 * 20), Color.Black);
		//    //Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 13 * 20), Color.Black);
		//    //Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 17 * 20), Color.Black);
		//    //Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 21 * 20), Color.Black);

		//    MyGame.Manager.SpriteManager.DrawSelect(OptionType.A);
		//    //MyGame.Manager.SpriteManager.DrawWrong(OptionType.B);
		//    //MyGame.Manager.SpriteManager.DrawBackArrow();
		//    //MyGame.Manager.SpriteManager.DrawPlayArrow();
		//    MyGame.Manager.SpriteManager.DrawVolumeOff();
		//    //MyGame.Manager.SpriteManager.DrawWrong(OptionType.C);
		//    //MyGame.Manager.SpriteManager.DrawRight(OptionType.D);

		//    MyGame.Manager.TextManager.Draw(TextDataList);

		//    Engine.Game.Window.Title = "Level";
		//}

	}
}