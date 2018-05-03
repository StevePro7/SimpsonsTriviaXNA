using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class OverScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public ScreenType Update(GameTime gameTime)
		{
			return ScreenType.Over;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawCurrActor();

			Engine.Game.Window.Title = "Over";
		}

	}
}