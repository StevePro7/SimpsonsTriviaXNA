using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Static;

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
			//var globalData = MyGame.Manager.ConfigManager.GlobalConfigData;
		}

		public static String BaseRoot { get; private set; }

		public static Vector2 GetLeftArrowPos()
		{
			UInt16 arrowHigh = Constants.ScreenHigh - Constants.SpriteSize + Constants.OffsetArrowY;
			return  new Vector2(0, arrowHigh);
		}
		public static Vector2 GetRghtArrowPos()
		{
			UInt16 arrowHigh = Constants.ScreenHigh - Constants.SpriteSize + Constants.OffsetArrowY;
			return new Vector2(Constants.ScreenWide - Constants.SpriteSize, arrowHigh);
		}

		public static Vector2 GetVolumePos()
		{
			return new Vector2(Constants.ScreenWide - Constants.SpriteSize - Constants.GameOffsetX, -Constants.TextsSize / 2.0f);
		}

	}
}