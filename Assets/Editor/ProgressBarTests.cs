using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using kmgr.fieldgame.UI;

public class ProgressBarTests
{

	[Test]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
	public void ShouldThrowExceptionWhenProgressValueOutOfRange()
	{
        var progressBar = new ProgressBar();

        progressBar.ProgressValue = 10000;
	}
}
