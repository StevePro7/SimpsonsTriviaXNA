using WindowsGame.Managers;
using NUnit.Framework;

namespace WindowsGame.UnitTests.Managers
{
	[TestFixture]
	public class RandomManagerTests : BaseUnitTests
	{
		private IRandomManager randomManager;

		[SetUp]
		public void SetUp()
		{
			randomManager = new RandomManager();
		}

		[Test]
		public void LoadContentDataTest()
		{
		}

		[TearDown]
		public void TearDown()
		{
			randomManager = null;
		}

	}
}