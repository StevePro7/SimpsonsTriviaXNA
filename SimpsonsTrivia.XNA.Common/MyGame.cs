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
		}

		public static void UnloadContent()
		{
		}

		public static void Update(GameTime gameTime)
		{
		}

		public static void Draw()
		{
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