UnityPython
===========
UnityPython is a plugin for Unity3D that provides support for running Python
2.x code in Unity3D on any platform which supports `System.Reflection.Emit`.

Special thanks to the developers of IronPython who developed the open-source
integration of Python and .NET, which this plugin uses.


Requirements
============
The build target must support `System.Reflection.Emit`. In the Unity3D docs, you
can find an up-to-date detailed list of which platforms support `Emit` or not
[here](https://docs.unity3d.com/Manual/ScriptingRestrictions.html).

As of Unity3D 2019.4 LTS, here is a chart of platform support for `Emit`:
| Platform (scripting backend)        | Is `System.Reflection.Emit` supported? |
|-------------------------------------|----------------------------------------|
| Android (IL2CPP)                    | No                                     |
| Android (Mono)                      | Yes                                    |
| iOS (IL2CPP)                        | No                                     |
| PlayStation 4 (IL2CPP)              | No                                     |
| PlayStation Vita (IL2CPP)           | No                                     |
| Standalone (IL2CPP)                 | No                                     |
| Standalone (Mono)                   | Yes                                    |
| Switch (IL2CPP)                     | No                                     |
| Universal Windows Platform (IL2CPP) | No                                     |
| Universal Windows Platform (.NET)   | Maybe*                                 |
| WebGL (IL2CPP)                      | No                                     |
| WiiU (Mono)                         | Yes                                    |
| XBox One (IL2CPP)                   | No                                     |

\* Unconfirmed, as Unity states that UWP (.NET) uses a ".NET Core class
   libraries subset" but fails to state what libraries are included in that
   subset. If you know the answer to this question, please open a PR.

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
