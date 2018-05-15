using System;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class TitleScreen : BaseScreen, IScreen
	{
		private UInt16 titleDelay;
		private Vector2[] whitePositions;
		private Boolean flag;

		public override void Initialize()
		{
			titleDelay = MyGame.Manager.ConfigManager.GlobalConfigData.TitleDelay;
			whitePositions = GetWhitePositions();
			flag = false;

			LoadTextData();
		}

		public override void LoadContent()
		{
			base.LoadContent();
			MyGame.Manager.SoundManager.PlayTitleMusic();
		}

		public ScreenType Update(GameTime gameTime)
		{
			UpdateTimer(gameTime);
			if (Timer > titleDelay)
			{
				Timer = 0;
				flag = !flag;
			}

			return ScreenType.Title;
		}

		public override void Draw()
		{
			MyGame.Manager.ImageManager.DrawTitle();
			MyGame.Manager.TextManager.Draw(TextDataList);

			//MyGame.Manager.SpriteManager.DrawVolumeOn();
			//MyGame.Manager.SpriteManager.DrawVolumeOff();

			// Flash Press Start
			if (!flag)
			{
				return;
			}
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[0]);
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[1]);
		}

		private Vector2[] GetWhitePositions()
		{
			Vector2[] positions = new Vector2[2];
			positions[0] = new Vector2(2 * Constants.TextsSize, 13 * Constants.TextsSize);
			positions[1] = new Vector2(4 * Constants.TextsSize, 13 * Constants.TextsSize);
			return positions;
		}

	}
}