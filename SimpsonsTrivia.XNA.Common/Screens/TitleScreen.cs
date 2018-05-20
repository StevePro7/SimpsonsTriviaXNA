﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Screens
{
	public class TitleScreen : BaseScreen, IScreen
	{
		private IList<Vector2> whitePositions;
		private UInt16 titleDelay;
		private Boolean flash, flag;

		public override void Initialize()
		{
			TextPositions = GetTextPositions();
			whitePositions = GetWhitePositions();
			titleDelay = MyGame.Manager.ConfigManager.GlobalConfigData.TitleDelay;
			flash = MyGame.Manager.ConfigManager.GlobalConfigData.FlashTitle;
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

			Boolean volume = MyGame.Manager.InputManager.VolumeIcon();
			if (volume)
			{
				MyGame.Manager.SoundManager.AlternateSound();
			}

			Boolean left = MyGame.Manager.InputManager.LeftArrow();
			Boolean rght = MyGame.Manager.InputManager.RghtArrow();

			// TODO tidy up
			if (left || rght)
			{
				MyGame.Manager.SoundManager.StopMusic();
				return ScreenType.Level;
			}

			return ScreenType.Title;
		}

		public override void Draw()
		{
			MyGame.Manager.TextManager.Draw(TextDataList);
			MyGame.Manager.TextManager.DrawText(Globalize.TITLE_LINE1, TextPositions[0]);
			MyGame.Manager.TextManager.DrawText(Globalize.TITLE_LINE2, TextPositions[1]);
			MyGame.Manager.TextManager.DrawText(Constants.BUILD_VERSION, TextPositions[2]);

			MyGame.Manager.ImageManager.DrawTitle();
			MyGame.Manager.SoundManager.DrawVolumeIcon();

			// Show / hide cheat mode text.
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[2]);
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[3]);

			// Flash Press Start
			if (!flash || !flag)
			{
				return;
			}
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[0]);
			MyGame.Manager.SpriteManager.DrawWhite(whitePositions[1]);
		}

		private IList<Vector2> GetTextPositions()
		{
			IList<Vector2> positions = new List<Vector2>();
			positions.Add(MyGame.Manager.TextManager.GetTextPosition(2, 13));
			positions.Add(MyGame.Manager.TextManager.GetTextPosition(2, 14));
			positions.Add(MyGame.Manager.TextManager.GetTextPosition(25, 23));
			return positions;
		}

		private IList<Vector2> GetWhitePositions()
		{
			IList<Vector2> positions = new List<Vector2>();
			// START
			positions.Add(MyGame.Manager.TextManager.GetWhitePosition(2, 13));
			positions.Add(MyGame.Manager.TextManager.GetWhitePosition(4, 13));

			// CHEAT
			positions.Add(MyGame.Manager.TextManager.GetWhitePosition(25, 9));
			positions.Add(MyGame.Manager.TextManager.GetWhitePosition(27, 9));

			// TODO remove
			//positions[0] = new Vector2(2 * Constants.TextsSize, 13 * Constants.TextsSize);
			//positions[1] = new Vector2(4 * Constants.TextsSize, 13 * Constants.TextsSize);
			//positions[2] = new Vector2(25 * Constants.TextsSize, 10 * Constants.TextsSize);
			//positions[3] = new Vector2(27 * Constants.TextsSize, 10 * Constants.TextsSize);
			return positions;
		}

	}
}