using WindowsGame.Common.Managers;
using NUnit.Framework;

namespace WindowsGame.UnitTests.Managers
{
	[TestFixture]
	public class RandomManagerTests : BaseUnitTests
	{
		[SetUp]
		public new void SetUp()
		{
			RandomManager = new RandomManager();
		}

		[Test]
		public void LoadContentDataTest()
		{
		}

		[TearDown]
		public void TearDown()
		{
			RandomManager = null;
		}

	}
}