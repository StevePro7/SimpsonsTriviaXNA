using System;

namespace WindowsGame.Common.Data
{
	public abstract class BaseData
	{
		public static void Initialize()
		{
			BaseRoot = String.Empty;
		}
		public static void Initialize(String root)
		{
			BaseRoot = root;
		}

		public static void LoadContent()
		{
			// Global generic data.
			var globalData = MyGame.Manager.ConfigManager.GlobalConfigData;
		}

		public static String BaseRoot { get; private set; }

		public static UInt16 SplashDelay { get; private set; }
	}
}