namespace CodeChallenge04_BowlingScorer
{
	public enum SingleBallScoreEnum
	{
		Null = -1, // NOTE: this represents the absence of a score and should never be used in the calculation
		Gutter = 0,
		One = 1,
		Two = 2,
		Three = 3,
		Four = 4,
		Five = 5,
		Six = 6,
		Seven = 7,
		Eight = 8,
		Nine = 9,
		Spare = 10,
		Strike = 100 // NOTE: strikes and spares are calculated differently in the code, since it depends on other ball scores
	}
}