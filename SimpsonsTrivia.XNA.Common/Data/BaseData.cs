﻿using Microsoft.Xna.Framework;
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

		public static Vector2[] GetPositionsSelect()
		{
			Vector2[] positionsSelect = new Vector2[Constants.NUMBER_OPTIONS];
			positionsSelect[(Byte)OptionType.A] = BaseData.GetPositionSelect(0, 7);
			positionsSelect[(Byte)OptionType.B] = BaseData.GetPositionSelect(0, 11);
			positionsSelect[(Byte)OptionType.C] = BaseData.GetPositionSelect(0, 15);
			positionsSelect[(Byte)OptionType.D] = BaseData.GetPositionSelect(0, 19);
			return positionsSelect;
		}

		public static Vector2 GetPositionSelect(Byte x, Byte y)
		{
			return new Vector2(Constants.GameOffsetX + x * Constants.SpriteTile + Constants.OffsetSelect, y * Constants.SpriteTile + Constants.OffsetSelect);
		}

		public static Vector2 GetLeftArrowPos()
		{
			const UInt16 arrowHigh = Constants.ScreenHigh - Constants.SpriteSize + Constants.OffsetArrowY;
			return new Vector2(0, arrowHigh);
		}
		public static Vector2 GetRghtArrowPos()
		{
			const UInt16 arrowHigh = Constants.ScreenHigh - Constants.SpriteSize + Constants.OffsetArrowY;
			return new Vector2(Constants.ScreenWide - Constants.SpriteSize, arrowHigh);
		}

		public static Vector2 GetVolumeIconPos()
		{
			return new Vector2(Constants.ScreenWide - Constants.SpriteSize - Constants.GameOffsetX, -Constants.TextsSize / 2.0f);
		}

		public static Vector2 GetCheatModePos()
		{
			return new Vector2(Constants.CheatModeOffsetX + Constants.GameOffsetX, Constants.CheatModeOffsetY);
		}

	}
}