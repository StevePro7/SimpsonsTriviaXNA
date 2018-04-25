﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using WindowsGame.Common.Library;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface IImageManager
	{
		void LoadContent();
		void DrawTitle();
		void DrawActor(Byte index);
	}

	public class ImageManager : IImageManager
	{
		private Rectangle titleRect;
		private Rectangle[] actorRects;
		
		private Vector2 titleVect;
		private Vector2 actorVect;
		private Single rotation;

		private const UInt16 imageWide = 240;
		private const UInt16 imageHigh = 320;

		public void LoadContent()
		{
			titleRect = new Rectangle(0, 0, 2 * imageWide, 2 * imageHigh);
			titleVect = new Vector2(480, 0);

			actorRects = PopulateActorRects();
			actorVect = new Vector2(Constants.GameOffsetX + Constants.ScreenWide - imageWide, Constants.ScreenHigh - imageHigh);
			rotation = MathHelper.ToRadians(270);
		}

		public void DrawTitle()
		{
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, Vector2.Zero, titleRect, Color.White, rotation, titleVect, 1.0f, SpriteEffects.None, 1.0f);
		}

		public void DrawActor(Byte index)
		{
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, actorVect, actorRects[index], Color.White);
		}

		private Rectangle[] PopulateActorRects()
		{
			actorRects = new Rectangle[Constants.NUMBER_CHARACTERS];
			actorRects[0] = GetRectangle(0, 2); actorRects[1] = GetRectangle(0, 3); actorRects[2] = GetRectangle(1, 2); actorRects[3] = GetRectangle(1, 3);
			actorRects[4] = GetRectangle(2, 0); actorRects[5] = GetRectangle(2, 1); actorRects[6] = GetRectangle(2, 2); actorRects[7] = GetRectangle(2, 3);
			actorRects[8] = GetRectangle(3, 0); actorRects[9] = GetRectangle(3, 1); actorRects[10] = GetRectangle(3, 2); actorRects[11] = GetRectangle(3, 3);
			actorRects[12] = GetRectangle(4, 0); actorRects[13] = GetRectangle(4, 1); actorRects[14] = GetRectangle(4, 2); actorRects[15] = GetRectangle(4, 3);
			return actorRects;
		}

		private Rectangle GetRectangle(Byte x, Byte y)
		{
			return new Rectangle(x * imageWide, y * imageHigh, imageWide, imageHigh);
		}

	}
}