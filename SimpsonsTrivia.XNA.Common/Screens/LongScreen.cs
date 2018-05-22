using WindowsGame.Common.Data;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class LongScreen : BaseScreen, IScreen
	{
		private Vector2 position;

		public override void Initialize()
		{
			position = BaseData.GetCheatModePos();

			LoadTextData();
		}

		public override void LoadContent()
		{
		}

		public ScreenType Update(GameTime gameTime)
		{
			return ScreenType.Long;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawTitle();
			MyGame.Manager.ImageManager.DrawSprite(SpriteType.White, position);
			//MyGame.Manager.TextManager.Draw(TextDataList);
			Engine.Game.Window.Title = "Long";
		}

	}
}