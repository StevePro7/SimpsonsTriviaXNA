using Microsoft.Xna.Framework;
using System;
using WindowsGame.Common.Data;
using WindowsGame.Common.Static;

namespace WindowsGame.Common.Managers
{
	public interface ICollisionManager
	{
		void LoadContent();

		Boolean LeftArrow(Int32 x, Int32 y);
		Boolean RghtArrow(Int32 x, Int32 y);
		Boolean VolumeIcon(Int32 x, Int32 y);
	}

	public class CollisionManager : ICollisionManager
	{
		private Rectangle leftArrowRect, rghtArrowRect;
		private Rectangle volumeIconRect;

		public void LoadContent()
		{
			Vector2 leftArrowPos = BaseData.GetLeftArrowPos();
			leftArrowRect = new Rectangle((Int16)leftArrowPos.X, (Int16)leftArrowPos.Y, Constants.SpriteSize, Constants.SpriteSize);

			Vector2 rghtArrowPos = BaseData.GetRghtArrowPos();
			rghtArrowRect = new Rectangle((Int16)rghtArrowPos.X, (Int16)rghtArrowPos.Y, Constants.SpriteSize, Constants.SpriteSize);

			Vector2 volumePos = BaseData.GetVolumePos();
			volumeIconRect = new Rectangle((Int16)volumePos.X, (Int16)volumePos.Y, Constants.SpriteSize, Constants.SpriteSize);
		}

		public Boolean LeftArrow(Int32 x, Int32 y)
		{
			return leftArrowRect.Contains(x, y);
		}

		public Boolean RghtArrow(Int32 x, Int32 y)
		{
			return rghtArrowRect.Contains(x, y);
		}

		public Boolean VolumeIcon(Int32 x, Int32 y)
		{
			return volumeIconRect.Contains(x, y);
		}

	}
}