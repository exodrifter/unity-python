using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

/// <summary>
/// Convenience class for creating a Python engine integrated with Unity.
///
/// All scripts executed by the ScriptEngine created by this class will:
/// * Be able to import any class in a `UnityEngine*` namespace
/// * Be able to import any class in a `UnityEditor*` namespace, if the script
///   is running in the UnityEditor
/// </summary>
public static class UnityPython
{
	public static ScriptEngine CreateEngine(IDictionary<string, object> options = null)
	{
		var engine = Python.CreateEngine(options);

		// Load assemblies for the `UnityEngine*` namespaces
		foreach (var assembly in GetAssembliesInNamespace("UnityEngine"))
		{
			engine.Runtime.LoadAssembly(assembly);
		}

#if UNITY_EDITOR
		// Load assemblies for the `UnityEditor*` namespaces
		foreach (var assembly in GetAssembliesInNamespace("UnityEditor"))
		{
			engine.Runtime.LoadAssembly(assembly);
		}
#endif

		return engine;
	}

	/// <summary>
	/// Get a list of all loaded assemblies in the current AppDomain for a
	/// namespace beginning with the specified string.
	/// </summary>
	/// <param name="prefix">The beginning of the namespace.</param>
	/// <returns>All matching assemblies.</returns>
	private static IEnumerable<Assembly> GetAssembliesInNamespace(string prefix)
	{
		return AppDomain.CurrentDomain.GetAssemblies()
			.SelectMany(t => t.GetTypes())
			.Where(t => t.Namespace != null && t.Namespace.StartsWith(prefix))
			.Select(t => t.Assembly)
			.Distinct();
	}
}
