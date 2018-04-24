﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Static;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Library;
using WindowsGame.Common.Data;

namespace WindowsGame.Common.Screens
{
	public class InitScreen : BaseScreen, IScreen
	{
		private ScreenType nextScreen;
		private Boolean join;

		public override void Initialize()
		{
			Single wide = (Constants.ScreenWide - Assets.SplashTexture.Width) / 2.0f;
			Single high = (Constants.ScreenHigh - Assets.SplashTexture.Height) / 2.0f;

			BannerPosition = new Vector2(wide, high);
			join = false;
		}

		public override void LoadContent()
		{
			base.LoadContent();
			MyGame.Manager.ThreadManager.LoadContentAsync();
		}

		public ScreenType Update(GameTime gameTime)
		{
			UpdateTimer(gameTime);

			// Do not attempt to progress until join.
			join = MyGame.Manager.ThreadManager.Join(1);
			if (!join)
			{
				return ScreenType.Init;
			}

			nextScreen = GetNextScreen();
			if (Timer > BaseData.SplashDelay)
			{
				return nextScreen;
			}

			Boolean next = MyGame.Manager.InputManager.Next();
			return next ? nextScreen : ScreenType.Init;
		}

		public override void Draw()
		{
			Engine.SpriteBatch.Draw(Assets.SplashTexture, BannerPosition, Color.White);
		}

		private static ScreenType GetNextScreen()
		{
			ScreenType screenType = MyGame.Manager.ConfigManager.GlobalConfigData.ScreenType;
			if (ScreenType.Splash == screenType || ScreenType.Init == screenType)
			{
				screenType = ScreenType.Title;
			}

			return screenType;
		}

	}
}