using CodeChallenge04_BowlingScorer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeChallenge04_BowlingScorer_UnitTests
{
	[TestClass]
	public class BowlingResultUnitTests
	{
		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void PerfectScoreIs300()
		{
			// Arrange
			var result = new BowlingResult("PlayerPerfect", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Strike)
			});

			// Act
			var score = result.CalculateScore();

			// Assert
			Assert.AreEqual(score, 300);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void AllGutterScoreIsZero()
		{
			// Arrange
			var result = new BowlingResult("PlayerGutter", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null)
			});

			// Act
			var score = result.CalculateScore();

			// Assert
			Assert.AreEqual(score, 0);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestScoreWithSpares()
		{
			// Arrange
			var result = new BowlingResult("PlayerWithSpares", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Six, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Five, SingleBallScoreEnum.Three, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Seven, SingleBallScoreEnum.One, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Eight)
			});

			// Act
			var score = result.CalculateScore();

			// Assert
			Assert.AreEqual(score, 128);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestScoreWithStrikes()
		{
			// Arrange
			var result = new BowlingResult("PlayerWithStrikes", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Six, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Three, SingleBallScoreEnum.Four, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Two, SingleBallScoreEnum.Seven)
			});

			// Act
			var score = result.CalculateScore();

			// Assert
			Assert.AreEqual(score, 145);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestScoreWithSparesAndStrikes()
		{
			// Arrange
			var result = new BowlingResult("PlayerWithSparesAndStrikes", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Eight, SingleBallScoreEnum.Spare, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Six, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Null, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Strike, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One)
			});

			// Act
			var score = result.CalculateScore();

			// Assert
			Assert.AreEqual(score, 167);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestScoreNoSparesOrStrikes()
		{
			// Arrange
			var result = new BowlingResult("PlayerNoSparesOrStrikes", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Six, SingleBallScoreEnum.Three, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Six, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Six, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Five, SingleBallScoreEnum.Four, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Two, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Five, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null)
			});

			// Act
			var score = result.CalculateScore();

			// Assert
			Assert.AreEqual(score, 73);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestDuplicateFrameNumbers()
		{
			// Arrange
			var duplicateFrameNumbers = new BowlingResult("PlayerNoSparesOrStrikes", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Six, SingleBallScoreEnum.Three, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Six, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Six, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Five, SingleBallScoreEnum.Four, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Two, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null)
			});

			// Act
			var framesNumbersAreValid = duplicateFrameNumbers.ValidateFrames();

			// Assert
			Assert.IsFalse(framesNumbersAreValid);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestTooFewFrames()
		{
			// Arrange
			var frames = new BowlingResult("PlayerNoSparesOrStrikes", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Six, SingleBallScoreEnum.Three, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Six, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Six, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Five, SingleBallScoreEnum.Four, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Two, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null),
			});

			// Act
			var framesNumbersAreValid = frames.ValidateFrames();

			// Assert
			Assert.IsFalse(framesNumbersAreValid);
		}

		[TestMethod]
		[TestCategory("UnitTestAll")]
		[TestCategory("UnitTestBowlingResults")]
		public void TestTooManyFrames()
		{
			// Arrange
			var frames = new BowlingResult("PlayerNoSparesOrStrikes", new[]
			{
				new BowlingFrame(1, SingleBallScoreEnum.Six, SingleBallScoreEnum.Three, SingleBallScoreEnum.Null),
				new BowlingFrame(2, SingleBallScoreEnum.Six, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(3, SingleBallScoreEnum.Nine, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(4, SingleBallScoreEnum.Seven, SingleBallScoreEnum.Two, SingleBallScoreEnum.Null),
				new BowlingFrame(5, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Null),
				new BowlingFrame(6, SingleBallScoreEnum.Gutter, SingleBallScoreEnum.Six, SingleBallScoreEnum.Null),
				new BowlingFrame(7, SingleBallScoreEnum.Five, SingleBallScoreEnum.Four, SingleBallScoreEnum.Null),
				new BowlingFrame(8, SingleBallScoreEnum.Two, SingleBallScoreEnum.Five, SingleBallScoreEnum.Null),
				new BowlingFrame(9, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null),
				new BowlingFrame(10, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null),
				new BowlingFrame(11, SingleBallScoreEnum.Eight, SingleBallScoreEnum.One, SingleBallScoreEnum.Null)
			});

			// Act
			var framesNumbersAreValid = frames.ValidateFrames();

			// Assert
			Assert.IsFalse(framesNumbersAreValid);
		}
	}
}
