using System;
using System.IO;

/// <summary>
/// Used to redirect IronPython output to the Unity debug console.
/// </summary>
public class UnityLogWriter : StreamWriter
{
	private readonly Action<string> logger;
	private string buffer = "";

	public UnityLogWriter(Action<string> logger, Stream s) : base(s)
	{
		if (logger == null)
		{
			throw new ArgumentNullException("logger");
		}
		this.logger = logger;
	}

	public override void Write(string value)
	{
		base.Write(value);
		buffer += value;

		var lines = buffer.Split('\n');
		for (var i = 0; i < lines.Length; ++i)
		{
			if (i == lines.Length - 1)
			{
				buffer = lines[i];
			}
			else
			{
				logger(lines[i]);
			}
		}
	}
}