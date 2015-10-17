UnityPython
===========
UnityPython is a plugin for Unity3D that provides support for running Python
code in Unity.

Special thanks to the developers of IronPython who developed the open-source
integration of Python and .NET, which this plugin uses.

Thanks to Steve Theodore of the [Tech Art Survival Guide](http://techartsurvival.blogspot.com/2013/12/embedding-ironpython-in-unity-tech-art.html)
who provided many instructions and examples.


Setup
=====
Place the source of this project within a "Plugins" folder. For convenience,
you can use the latest `.unitypackage` release from the [releases]
(https://github.com/exodrifter/unity-python/releases) page to do this.

Then, go to `Edit > Project Settings > Player > Optimization` and select the
`.NET 2.0` option for Api Compatability Level.

If you would like to use this project only in the Editor, changing the Api
Compatability Level is unnecessary. Instead, place the project inside an
"Editor" folder.


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
