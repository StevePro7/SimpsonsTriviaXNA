using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class LevelScreen : BaseScreen, IScreen
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
			return ScreenType.Level;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawHeader();

			byte index = MyGame.Manager.ConfigManager.GlobalConfigData.ActorIndex;
			MyGame.Manager.ImageManager.DrawActor(index);

			// TODO - fix with offset
			Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 9 * 20), Color.Black);
			Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 13 * 20), Color.Black);
			Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 17 * 20), Color.Black);
			Engine.SpriteBatch.DrawString(Assets.EmulogicFont, "A.", new Vector2(2 * 20, 21 * 20), Color.Black);

			MyGame.Manager.SpriteManager.DrawSelect(OptionType.A);
			MyGame.Manager.SpriteManager.DrawWrong(OptionType.B);
			MyGame.Manager.SpriteManager.DrawWrong(OptionType.C);
			MyGame.Manager.SpriteManager.DrawRight(OptionType.D);

			MyGame.Manager.TextManager.Draw(TextDataList);

			Engine.Game.Window.Title = "Level";
		}

	}
}