using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Objects;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class LevelScreen : BaseScreen, IScreen
	{
		private Byte questionNo;
		private Boolean cheatMode;
		private OptionType optionType;

		public override void Initialize()
		{
			LoadTextData();
		}

		public override void LoadContent()
		{
			MyGame.Manager.ImageManager.GenerateNextActor();

			// TODO implement logic from TitleScreen
			cheatMode = MyGame.Manager.ConfigManager.GlobalConfigData.CheatMode;

			questionNo = MyGame.Manager.QuestionManager.QuestionNumber;
			MyGame.Manager.QuestionManager.LoadQuestion(questionNo);
			if (MyGame.Manager.ConfigManager.GlobalConfigData.RandomAnswers)
			{
				MyGame.Manager.QuestionManager.RandomizeAnswerList(questionNo);
			}

			// Correct option is now set!
			optionType = GetOptionType();
		}

		public ScreenType Update(GameTime gameTime)
		{
			//// TODO elevate to the base class
			//Boolean volume = MyGame.Manager.InputManager.VolumeIcon();
			//if (volume)
			//{
			//	MyGame.Manager.SoundManager.AlternateSound();
			//}

			////Boolean left = MyGame.Manager.InputManager.LeftArrow();
			////if (left)
			////{
			////    MyGame.Manager.SoundManager.PlayWrongSoundEffect();
			////}
			//Boolean rght = MyGame.Manager.InputManager.RghtArrow();
			//if (rght)
			//{
			//	//MyGame.Manager.SoundManager.PlayRightSoundEffect();
			//	return ScreenType.Over;
			//}

			return ScreenType.Play;
		}

		public override void Draw()
		{
			// Draw all text first.
			MyGame.Manager.QuestionManager.DrawQuestion(questionNo);
			MyGame.Manager.QuestionManager.DrawQuestionNumber();
			MyGame.Manager.QuestionManager.DrawQuestionTotal();
			MyGame.Manager.TextManager.Draw(TextDataList);

			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			//if (cheatMode)
			//{
			//    MyGame.Manager.SpriteManager.DrawSelect(optionType);
			//}
			//else
			//{
			//    MyGame.Manager.SpriteManager.DrawSelectAll();
			//}

			MyGame.Manager.SoundManager.DrawVolumeIcon();

			//MyGame.Manager.DeviceManager.DrawBackButton();
			MyGame.Manager.DeviceManager.DrawViewButton();

			MyGame.Manager.SoundManager.DrawVolumeIcon();

			Engine.Game.Window.Title = "Level";
		}

		//public override void DrawY()
		//{
		//	MyGame.Manager.QuestionManager.DrawQuestion(0);
		//	MyGame.Manager.TextManager.Draw(TextDataList);

		//	MyGame.Manager.ImageManager.DrawHeader();
		//	MyGame.Manager.ImageManager.DrawCurrActor();

		//	MyGame.Manager.SpriteManager.DrawSelectAll();
		//	MyGame.Manager.SoundManager.DrawVolumeIcon();

		//	//MyGame.Manager.DeviceManager.DrawBackButton();
		//	MyGame.Manager.DeviceManager.DrawViewButton();

		//	Engine.Game.Window.Title = "Level";
		//}

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

		private static OptionType GetOptionType()
		{
			return MyGame.Manager.QuestionManager.CorrectOptionType;
			//Question q = MyGame.Manager.QuestionManager.QuestionList[questNo];
			//return (OptionType)(q.AnswerCode - 1);
		}

	}
}