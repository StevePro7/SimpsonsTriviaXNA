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
			LoadTextData();
		}

		public override void LoadContent()
		{
			MyGame.Manager.ImageManager.GenerateNextActor();
		}

		public ScreenType Update(GameTime gameTime)
		{
			return ScreenType.Play;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawHeader();
			MyGame.Manager.ImageManager.DrawNextActor();

			//byte index = MyGame.Manager.ConfigManager.GlobalConfigData.ActorIndex;
			//MyGame.Manager.ImageManager.DrawActor(index);

			MyGame.Manager.TextManager.Draw(TextDataList);
			Engine.Game.Window.Title = "Play";
		}

	}
}