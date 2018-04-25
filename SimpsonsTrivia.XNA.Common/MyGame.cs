using Microsoft.Xna.Framework;
using WindowsGame.Common.TheGame;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;
using System;

namespace WindowsGame
{
	public static class MyGame
	{
		public static void Construct(IGameManager manager)
		{
			Manager = manager;
		}

		public static void Initialize()
		{
			Manager.Logger.Initialize();
			Manager.ConfigManager.Initialize();
			Manager.ConfigManager.LoadContent();

			Manager.ContentManager.Initialize();
			Manager.ContentManager.LoadContentSplash();

			Manager.InputManager.Initialize();
			Manager.ScoreManager.Initialize();

			Manager.ResolutionManager.Initialize();
			Manager.ScreenManager.Initialize();
			Manager.ThreadManager.Initialize();
		}

		public static void LoadContent()
		{
			Engine.Game.IsFixedTimeStep = Constants.IsFixedTimeStep;
			Engine.Game.TargetElapsedTime = TimeSpan.FromSeconds(1.0f / Constants.FramesPerSecond);
			Engine.Game.IsMouseVisible = Constants.IsMouseVisible;

			Boolean isFullScreen = Constants.IsFullScreen;
			Manager.ResolutionManager.LoadContent(isFullScreen, Constants.ScreenWide, Constants.ScreenHigh, Constants.UseExposed, Constants.ExposeWide, Constants.ExposeHigh);
		}

		public static void LoadContentAsync()
		{
			Manager.ConfigManager.LoadContent();
			Manager.ContentManager.LoadContent();
			Manager.ImageManager.LoadContent();

			Manager.ScoreManager.LoadContent();
			Manager.TextManager.LoadContent();
			Manager.ScreenManager.LoadContent();

			GC.Collect();
		}

		public static void UnloadContent()
		{
			Engine.Game.Content.Unload();
		}

		public static void Update(GameTime gameTime)
		{
			Manager.InputManager.Update(gameTime);

#if WINDOWS
			if (MyGame.Manager.ConfigManager.GlobalConfigData.QuitsToExit)
			{
				Boolean escape = Manager.InputManager.Escape();
				if (escape)
				{
					Engine.Game.Exit();
					return;
				}
			}
#endif

			Manager.ScreenManager.Update(gameTime);
		}

		public static void Draw()
		{
			Manager.ScreenManager.Draw();
		}

		public static void OnActivated()
		{
		}
		public static void OnDeactivated()
		{
		}

		public static IGameManager Manager { get; private set; }
	}
}