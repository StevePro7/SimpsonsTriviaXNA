using System;
using Microsoft.Xna.Framework;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface ISpriteManager
	{
		void Initialize();

		void DrawSelect(OptionType optionType);
		void DrawRight(OptionType optionType);
		void DrawWrong(OptionType optionType);
	}

	public class SpriteManager : ISpriteManager
	{
		private Vector2[] positions;
		private const UInt16 spriteTile = 20;		// TODO - believe this is wrong

		public void Initialize()
		{
			positions = GetPositions();
		}

		// TODO - don't forget to allow offset for right and wrong sprites
		public void DrawSelect(OptionType optionType)
		{
			DrawSprite(SpriteType.Select, optionType);
		}

		public void DrawRight(OptionType optionType)
		{
			DrawSprite(SpriteType.Right, optionType);
		}

		public void DrawWrong(OptionType optionType)
		{
			DrawSprite(SpriteType.Wrong, optionType);
		}

		private void DrawSprite(SpriteType spriteType, OptionType optionType)
		{
			Vector2 position = positions[(Byte)optionType];
			MyGame.Manager.ImageManager.DrawSprite(spriteType, position);
		}

		private Vector2[] GetPositions()
		{
			positions = new Vector2[Constants.NUMBER_OPTIONS];
			positions[(Byte)OptionType.A] = GetPosition(4, 9);
			positions[(Byte)OptionType.B] = GetPosition(4, 13);
			positions[(Byte)OptionType.C] = GetPosition(4, 17);
			positions[(Byte)OptionType.D] = GetPosition(4, 21);
			return positions;
		}

		private Vector2 GetPosition(Byte x, Byte y)
		{
			// TODO - perfect the actual tile size!
			return new Vector2(x * spriteTile, y * spriteTile);
		}

	}
}