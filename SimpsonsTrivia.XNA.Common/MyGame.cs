using Microsoft.Xna.Framework;
using WindowsGame.Common.TheGame;

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
		}

		public static void LoadContent()
		{
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