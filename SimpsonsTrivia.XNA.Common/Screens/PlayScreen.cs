using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class PlayScreen : BaseScreen, IScreen
	{
		public override void Initialize()
		{
		}

		public override void LoadContent()
		{
		}

		public ScreenType Update(GameTime gameTime)
		{
			return ScreenType.Play;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawHeader();

			Vector2 pos = new Vector2(100, 100);
			MyGame.Manager.ImageManager.DrawSprite(pos);

			Engine.Game.Window.Title = "Play";
		}

	}
}