using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Collections.Generic;

public sealed class UnityPython
{
	public static ScriptEngine CreateEngine()
	{
		return CreateEngine(null);
	}

	public static ScriptEngine CreateEngine(IDictionary<string, object> options)
	{
		ScriptEngine engine;
		if (options == null)
		{
			engine = Python.CreateEngine();
		}
		else
		{
			engine = Python.CreateEngine(options);
		}

		var unityEngine = typeof(UnityEngine.GameObject).Assembly;
		engine.Runtime.LoadAssembly(unityEngine);

#if UNITY_EDITOR
		var unityEditor = typeof(UnityEditor.Editor).Assembly;
		engine.Runtime.LoadAssembly(unityEditor);
#endif

		return engine;
	}
}
