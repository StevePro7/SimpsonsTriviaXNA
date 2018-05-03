using Microsoft.Xna.Framework;
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

			MyGame.Manager.TextManager.Draw(TextDataList);
			Engine.Game.Window.Title = "Quiz";
		}

	}
}