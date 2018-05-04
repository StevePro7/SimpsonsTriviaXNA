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
		private const Byte spriteTile = 20;
		private const Byte offsetSelect = 10;
		private const Byte offsetAnswerY = 18;

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
			positions[(Byte)OptionType.A] = GetPosition(0, 7);
			positions[(Byte)OptionType.B] = GetPosition(0, 11);
			positions[(Byte)OptionType.C] = GetPosition(0, 15);
			positions[(Byte)OptionType.D] = GetPosition(0, 19);
			return positions;
		}

		private Vector2 GetPosition(Byte x, Byte y)
		{
			// SELECT
			return new Vector2(x * spriteTile + offsetSelect, y * spriteTile + offsetSelect);

			// RIGHT / WRONG
			//return new Vector2(x * spriteTile, y * spriteTile + offsetAnswerY);
		}

	}
}