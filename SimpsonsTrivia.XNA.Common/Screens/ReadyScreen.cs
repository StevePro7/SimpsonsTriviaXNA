using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class ReadyScreen : BaseScreen, IScreen
	{
		private IList<Vector2> quizPositions;
		private DifficultyType difficultyType;
		private Byte numberQuestion;
		private UInt16 delay;
		private Boolean cheatMode, flag;
		private string diffText, longText;

		public override void Initialize()
		{
			base.Initialize();
			quizPositions = GetQuizPositions();

			delay = MyGame.Manager.ConfigManager.GlobalConfigData.ReadyDelay;
			LoadTextData();
		}

		public override void LoadContent()
		{
			base.LoadContent();
			cheatMode = MyGame.Manager.QuestionManager.GetCheatMode();

			// TODO REMOVE
			Boolean testData = MyGame.Manager.ConfigManager.GlobalConfigData.TestData;
			if (testData)
			{
				MyGame.Manager.QuestionManager.SetDifficulty(OptionType.A);
				MyGame.Manager.QuestionManager.SetQuizLength(OptionType.A);
			}
			// TODO REMOVE

			difficultyType = MyGame.Manager.QuestionManager.DifficultyType;
			numberQuestion = MyGame.Manager.QuestionManager.NumberQuestion;
			
			diffText = MyGame.Manager.QuestionManager.DifficultyText;
			longText = MyGame.Manager.QuestionManager.QuizLengthText2;

			MyGame.Manager.ScoreManager.LoadContent();
			flag = false;
		}

		public ScreenType Update(GameTime gameTime)
		{
			UpdateVolumeIcon();
			Boolean escape = MyGame.Manager.InputManager.Escape();
			if (escape)
			{
				return ScreenType.Exit;
			}

			if (!flag)
			{
				Boolean leftArrow = MyGame.Manager.InputManager.LeftArrow();
				if (leftArrow)
				{
					return ScreenType.Long;
				}

				UpdateTimer(gameTime);
				if (Timer > delay)
				{
					flag = true;
				}
			}

			// Check if advance or timer complete
			Boolean advance = MyGame.Manager.InputManager.Advance();
			Boolean rghtArrow = MyGame.Manager.InputManager.RghtArrow();
			if (advance || rghtArrow)
			{
				flag = true;
			}

			if (flag)
			{
				// Reset question manager + load quiz.
				MyGame.Manager.QuestionManager.Reset();
				MyGame.Manager.QuestionManager.LoadQuestionList(difficultyType);

				if (MyGame.Manager.ConfigManager.GlobalConfigData.RandomQuestions)
				{
					MyGame.Manager.QuestionManager.RandomizeQuestionList();
				}

				MyGame.Manager.SoundManager.StopMusic();
				return ScreenType.Play;
			}

			return ScreenType.Ready;
		}

		public override void Draw()
		{
			// Draw all text first.
			MyGame.Manager.TextManager.Draw(TextDataList);
			MyGame.Manager.TextManager.DrawText(Constants.BUILD_VERSION, BuildPosition);
			MyGame.Manager.TextManager.DrawText(diffText, quizPositions[0]);
			MyGame.Manager.TextManager.DrawText(longText, quizPositions[1]);
			MyGame.Manager.TextManager.DrawText(" ", quizPositions[1]);

			// Draw all images next.
			MyGame.Manager.ImageManager.DrawTitle();
			MyGame.Manager.SoundManager.DrawVolumeIcon();
			MyGame.Manager.DeviceManager.DrawBackButton();
			MyGame.Manager.DeviceManager.DrawPlayButton();

			// Show / hide cheat mode text.
			if (!cheatMode)
			{
				HideCheatMode();
			}
		}

		private static IList<Vector2> GetQuizPositions()
		{
			IList<Vector2> positions = new List<Vector2>();
			positions.Add(MyGame.Manager.TextManager.GetTextPosition(2, 7));
			positions.Add(MyGame.Manager.TextManager.GetTextPosition(2, 12));
			
			return positions;
		}

	}
}