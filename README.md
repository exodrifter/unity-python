UnityPython
===========
UnityPython is a plugin for Unity3D that provides support for running Python
code in Unity.

Special thanks to the developers of IronPython who developed the open-source
integration of Python and .NET, which this plugin uses.


Setup
=====
Place the source of this project anywhere in the "Assets" folder. For
convenience, you can use the latest `.unitypackage` release from the
[releases][] page to do this.


Usage
=====
An example is provided below. More examples can be found in the
`Examples/` folder.

	using UnityEngine;
	using IronPython.Hosting;

	public class HelloWorld : MonoBehaviour
	{
		void Start()
		{
			var engine = Python.CreateEngine();
			var scope = engine.CreateScope();

			string code = "str = 'Hello world!'";

			var source = engine.CreateScriptSourceFromString(code);
			source.Execute(scope);

			Debug.Log(scope.GetVariable<string>("str"));
		}
	}


[releases]: https://github.com/exodrifter/unity-python/releases
