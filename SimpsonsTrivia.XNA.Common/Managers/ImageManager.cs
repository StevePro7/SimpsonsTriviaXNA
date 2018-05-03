using System;
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
		void DrawHeader();
		void DrawCurrActor();
		void DrawNextActor();
		void DrawActor(Byte index);
		void DrawSprite(SpriteType spriteType, Vector2 position);
	}

	public class ImageManager : IImageManager
	{
		private Rectangle titleRect, headerRect;
		private Vector2 titleVect, headerVect;

		private Rectangle[] actorRects;
		private Vector2 actorVect;

		private Rectangle[] spriteRects;
		private Single rotation;

		private const UInt16 imageWide = 240;
		private const UInt16 imageHigh = 320;
		private const UInt16 spriteSize = 80;

		private Byte currActor, nextActor;

		public void LoadContent()
		{
			titleRect = new Rectangle(0, 0, 2 * imageWide, 2 * imageHigh);
			titleVect = new Vector2(imageWide * 2, 0);

			headerRect = new Rectangle(4 * imageHigh - spriteSize, 0, spriteSize, 2 * imageHigh);
			headerVect = new Vector2(spriteSize, 0); 

			actorRects = PopulateActorRects();
			actorVect = new Vector2(Constants.GameOffsetX + Constants.ScreenWide - imageWide, Constants.ScreenHigh - imageHigh);

			spriteRects = PopulateSpriteRects();
			rotation = MathHelper.ToRadians(270);

			currActor = Constants.NUMBER_CHARACTERS;
			nextActor = 0;
		}

		public void DrawTitle()
		{
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, Vector2.Zero, titleRect, Color.White, rotation, titleVect, 1.0f, SpriteEffects.None, 1.0f);
		}

		public void DrawHeader()
		{
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, Vector2.Zero, headerRect, Color.White, rotation, headerVect, 1.0f, SpriteEffects.None, 1.0f);
		}

		public void DrawCurrActor()
		{
			DrawActor(currActor);
		}
		public void DrawNextActor()
		{
			DrawActor(nextActor);
		}
		public void DrawActor(Byte index)
		{
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, actorVect, actorRects[index], Color.White);
		}

		public void DrawSprite(SpriteType spriteType, Vector2 position)
		{
			Engine.SpriteBatch.Draw(Assets.SpritesheetTexture, position, spriteRects[(Byte)spriteType], Color.White);
		}

		private Rectangle[] PopulateActorRects()
		{
			actorRects = new Rectangle[Constants.NUMBER_CHARACTERS];
			actorRects[0] = GetActorRect(0, 2); actorRects[1] = GetActorRect(0, 3); actorRects[2] = GetActorRect(1, 2); actorRects[3] = GetActorRect(1, 3);
			actorRects[4] = GetActorRect(2, 0); actorRects[5] = GetActorRect(2, 1); actorRects[6] = GetActorRect(2, 2); actorRects[7] = GetActorRect(2, 3);
			actorRects[8] = GetActorRect(3, 0); actorRects[9] = GetActorRect(3, 1); actorRects[10] = GetActorRect(3, 2); actorRects[11] = GetActorRect(3, 3);
			actorRects[12] = GetActorRect(4, 0); actorRects[13] = GetActorRect(4, 1); actorRects[14] = GetActorRect(4, 2); actorRects[15] = GetActorRect(4, 3);
			return actorRects;
		}
		private Rectangle GetActorRect(Byte x, Byte y)
		{
			return new Rectangle(x * imageWide, y * imageHigh, imageWide, imageHigh);
		}

		private Rectangle[] PopulateSpriteRects()
		{
			spriteRects = new Rectangle[Constants.NUMBER_SPRITES];
			spriteRects[(Byte)SpriteType.Select] = GetSpriteRect(4 * imageHigh - spriteSize, 2 * imageHigh + 0 * spriteSize);
			spriteRects[(Byte)SpriteType.Right] = GetSpriteRect(4 * imageHigh - spriteSize, 2 * imageHigh + 1 * spriteSize);
			spriteRects[(Byte)SpriteType.Wrong] = GetSpriteRect(4 * imageHigh - spriteSize, 2 * imageHigh + 2 * spriteSize);
			return spriteRects;
		}
		private Rectangle GetSpriteRect(UInt16 x, UInt16 y)
		{
			return new Rectangle(x, y, spriteSize, spriteSize);
		}

		private Rectangle GetRectangle(UInt16 x, UInt16 y, UInt16 size)
		{
			return GetRectangle(x, y, size, size);
		}
		private Rectangle GetRectangle(UInt16 x, UInt16 y, UInt16 wide, UInt16 high)
		{
			return new Rectangle(x, y, wide, high);
		}

		// Rectangle + Vector2 raw data:
		// titleRect = new Rectangle(0, 0, 480, 640);
		// titleVect = new Vector2(640, 0);
		// headerRect = new Rectangle(1200, 0, 80, 640);
		// headerVect = new Vector2(80, 0);
		// selectRect = new Rectangle(1200, 640, 80, 80);
		// rightRect = new Rectangle(1200, 720, 80, 80);
		// wrongRect = new Rectangle(1200, 8000, 80, 80);
	}
}