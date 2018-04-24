using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame.Common.Interfaces;
using WindowsGame.Common.Library;
using WindowsGame.Common.Screens;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface IScreenManager
	{
		void Initialize();
		void LoadContent();
		void Update(GameTime gameTime);
		void Draw();
	}

	public class ScreenManager : IScreenManager
	{
		private IDictionary<ScreenType, IScreen> screens;
		private ScreenType currScreen = ScreenType.Splash;
		private ScreenType nextScreen = ScreenType.Splash;

		public void Initialize()
		{
			screens = GetScreens();
			screens[ScreenType.Splash].Initialize();
			screens[ScreenType.Init].Initialize();
		}

		public void LoadContent()
		{
			foreach (var key in screens.Keys)
			{
				if (ScreenType.Splash == key || ScreenType.Init == key)
				{
					continue;
				}

				screens[key].Initialize();
			}
		}

		public void Update(GameTime gameTime)
		{
			if (currScreen != nextScreen)
			{
				currScreen = nextScreen;
				screens[currScreen].LoadContent();
			}

			nextScreen = screens[currScreen].Update(gameTime);
		}

		public void Draw()
		{
			MyGame.Manager.ResolutionManager.BeginDraw();
			Engine.SpriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, null, MyGame.Manager.ResolutionManager.TransformationMatrix);
			screens[currScreen].Draw();
			Engine.SpriteBatch.End();
		}

		private static Dictionary<ScreenType, IScreen> GetScreens()
		{
			return new Dictionary<ScreenType, IScreen>
			{
				{ScreenType.Splash, new SplashScreen()},
				{ScreenType.Init, new InitScreen()},
				{ScreenType.Title, new TitleScreen()},
			};
		}

	}
}