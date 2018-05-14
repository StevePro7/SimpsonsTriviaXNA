using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class TitleScreen : BaseScreen, IScreen
	{
		private Vector2[] whitePositions;

		public override void Initialize()
		{
			whitePositions = GetWhitePositions();
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

			//MyGame.Manager.SpriteManager.DrawVolumeOn();
			//MyGame.Manager.SpriteManager.DrawVolumeOff();

			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[0]);
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[1]);
		}

		private Vector2[] GetWhitePositions()
		{
			Vector2[] positions = new Vector2[2];
			positions[0] = new Vector2(2 * Constants.TextsSize, 13 * Constants.TextsSize);
			positions[1] = new Vector2(3 * Constants.TextsSize, 13 * Constants.TextsSize);
			return positions;
		}

	}
}