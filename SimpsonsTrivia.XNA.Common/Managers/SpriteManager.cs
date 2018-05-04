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
		//private Vector2[] positions;
		private Vector2[] positionsSelect;
		private Vector2[] positionsAnswer;
		private const Byte spriteTile = 20;
		private const Byte offsetSelect = 10;
		private const Byte offsetAnswerY = 18;

		public void Initialize()
		{
		//	positions = GetPositions();
			positionsSelect = GetPositionsSelect();
			positionsAnswer = GetPositionsAnswer();
		}

		// TODO - don't forget to allow offset for right and wrong sprites
		public void DrawSelect(OptionType optionType)
		{
			Vector2 position = positionsSelect[(Byte)optionType];
			DrawSprite(SpriteType.Select, optionType, position);
		}

		public void DrawRight(OptionType optionType)
		{
			Vector2 position = positionsAnswer[(Byte)optionType];
			DrawSprite(SpriteType.Right, optionType, position);
		}

		public void DrawWrong(OptionType optionType)
		{
			Vector2 position = positionsAnswer[(Byte)optionType];
			DrawSprite(SpriteType.Wrong, optionType, position);
		}

		private void DrawSprite(SpriteType spriteType, OptionType optionType, Vector2 position)
		{
			MyGame.Manager.ImageManager.DrawSprite(spriteType, position);
		}

		private Vector2[] GetPositionsSelect()
		{
			//positions = new Vector2[Constants.NUMBER_OPTIONS];
			positionsSelect = new Vector2[Constants.NUMBER_OPTIONS];
			//positionsAnswer = new Vector2[Constants.NUMBER_OPTIONS];

			positionsSelect[(Byte)OptionType.A] = GetPositionSelect(0, 7);
			positionsSelect[(Byte)OptionType.B] = GetPositionSelect(0, 11);
			positionsSelect[(Byte)OptionType.C] = GetPositionSelect(0, 15);
			positionsSelect[(Byte)OptionType.D] = GetPositionSelect(0, 19);

			//positions[(Byte)OptionType.A] = GetPosition(0, 7);
			//positions[(Byte)OptionType.B] = GetPosition(0, 11);
			//positions[(Byte)OptionType.C] = GetPosition(0, 15);
			//positions[(Byte)OptionType.D] = GetPosition(0, 19);
			return positionsSelect;
		}

		private Vector2[] GetPositionsAnswer()
		{
			positionsAnswer = new Vector2[Constants.NUMBER_OPTIONS];
			positionsAnswer[(Byte)OptionType.A] = GetPositionAnswer(0, 7);
			positionsAnswer[(Byte)OptionType.B] = GetPositionAnswer(0, 11);
			positionsAnswer[(Byte)OptionType.C] = GetPositionAnswer(0, 15);
			positionsAnswer[(Byte)OptionType.D] = GetPositionAnswer(0, 19);
			return positionsAnswer;
		}

		//private Vector2 GetPosition(Byte x, Byte y)
		//{
		//    // SELECT
		//    return new Vector2(x * spriteTile + offsetSelect, y * spriteTile + offsetSelect);

		//    // RIGHT / WRONG
		//    //return new Vector2(x * spriteTile, y * spriteTile + offsetAnswerY);
		//}

		private Vector2 GetPositionSelect(Byte x, Byte y)
		{
			return new Vector2(x * spriteTile + offsetSelect, y * spriteTile + offsetSelect);
		}

		private Vector2 GetPositionAnswer(Byte x, Byte y)
		{
			return new Vector2(x * spriteTile, y * spriteTile + offsetAnswerY);
		}


	}
}