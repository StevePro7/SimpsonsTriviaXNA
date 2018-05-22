using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class ReadyScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public ScreenType Update(GameTime gameTime)
		{
			// Reset question manager + load quiz.
			MyGame.Manager.QuestionManager.Reset();
			MyGame.Manager.QuestionManager.LoadQuestionList(DifficultyType.Easy);

			if (MyGame.Manager.ConfigManager.GlobalConfigData.RandomQuestions)
			{
				MyGame.Manager.QuestionManager.RandomizeQuestionList();
			}

			return ScreenType.Level;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawTitle();

			Engine.Game.Window.Title = "Ready";
		}

	}
}