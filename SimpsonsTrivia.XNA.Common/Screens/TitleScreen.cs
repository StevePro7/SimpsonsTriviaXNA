using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Static;
using WindowsGame.Common.Library;

namespace WindowsGame.Common.Screens
{
	public class TitleScreen : BaseScreen, IScreen
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
			return ScreenType.Title;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawTitle();
			MyGame.Manager.TextManager.Draw(TextDataList);
			//MyGame.Manager.ImageManager.DrawHeader();

			//MyGame.Manager.ImageManager.DrawTitle();
			//byte index = MyGame.Manager.ConfigManager.GlobalConfigData.ActorIndex;
			//MyGame.Manager.ImageManager.DrawActor(index);

			MyGame.Manager.SpriteManager.DrawVolumeOn();
			//MyGame.Manager.SpriteManager.DrawVolumeOff();
		}

	}
}