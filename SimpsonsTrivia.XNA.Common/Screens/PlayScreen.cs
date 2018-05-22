using WindowsGame.Common.Objects;
using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class PlayScreen : BaseScreen, IScreen
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
			// TODO implement logic from TitleScreen
			cheatMode = MyGame.Manager.ConfigManager.GlobalConfigData.CheatMode;

			questionNo = MyGame.Manager.QuestionManager.QuestionNumber;
			optionType = GetOptionType();
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
				return ScreenType.Score;
			}
			Boolean rght = MyGame.Manager.InputManager.RghtArrow();
			if (rght)
			{
				// TODO
				//return ScreenType.Score;
				MyGame.Manager.QuestionManager.Increment();
				return ScreenType.Level;
			}

			//OptionType optionType = MyGame.Manager.InputManager.GetOptionType();
			//if (OptionType.None != optionType)
			//{
			//    MyGame.Manager.Logger.Info("option : " + optionType);
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

			if (cheatMode)
			{
				MyGame.Manager.SpriteManager.DrawSelect(optionType);
			}
			else
			{
				MyGame.Manager.SpriteManager.DrawSelectAll();
			}

			MyGame.Manager.SoundManager.DrawVolumeIcon();

			//MyGame.Manager.DeviceManager.DrawBackButton();
			MyGame.Manager.DeviceManager.DrawViewButton();

			MyGame.Manager.SoundManager.DrawVolumeIcon();

			Engine.Game.Window.Title = "Play";
		}

		private static OptionType GetOptionType()
		{
			return MyGame.Manager.QuestionManager.CorrectOptionType;
			//Question q = MyGame.Manager.QuestionManager.QuestionList[questNo];
			//return (OptionType)(q.AnswerCode - 1);
		}

	}
}