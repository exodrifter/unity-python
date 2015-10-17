using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public sealed class UnityPython
{
	public static ScriptEngine CreateEngine()
	{
		var engine = Python.CreateEngine();

		var unityEngine = typeof(UnityEngine.GameObject).Assembly;
		engine.Runtime.LoadAssembly(unityEngine);

#if UNITY_EDITOR
		var unityEditor = typeof(UnityEditor.Editor).Assembly;
		engine.Runtime.LoadAssembly(unityEditor);
#endif

		return engine;
	}
}
