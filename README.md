# Warning
**This repository is no longer maintained.** This repository will not be
updated and I will not respond to support requests. There are a few reasons
for why this is:

* Python 2 was deprecated on January 1, 2020.
* As of this writing, IronPython does not have a stable release for Python 3.
* Updating to newer versions of IronPython for Python 2 does not appear to be
  straightforward as IronPython links against newer versions of DLLs that
  Unity uses.
* pip dropped support for Python 2 in January 2021
* I no longer use Unity.

This makes it difficult for me to keep the repository up to date and provide
support. If you are interested in taking over, I would recommend putting
your energy towards moving to Python 3 using IronPython 3 instead of
continuing to use IronPython 2. Let me know if this is what you would like to
do; I can provide some limited advice based on my experience making this
library and I can redirect users to your library when it's ready.


# UnityPython
UnityPython is a plugin for Unity3D that provides support for running Python
2.x code in Unity3D on any platform which supports `System.Reflection.Emit`.

Special thanks to the developers of IronPython who developed the open-source
integration of Python and .NET, which this plugin uses.


## Requirements
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
| Universal Windows Platform (.NET)   | Maybe\*                                |
| WebGL (IL2CPP)                      | No                                     |
| WiiU (Mono)                         | Yes                                    |
| XBox One (IL2CPP)                   | No                                     |

\* Unconfirmed, as Unity states that UWP (.NET) uses a ".NET Core class
   libraries subset" but fails to state what libraries are included in that
   subset. If you know the answer to this question, please open a PR.


## Setup
There are three different ways to use this library in Unity:
* Use the `Add package from git URL...` option in Unity's package manager and
  use the git URL of this repository.
* Clone this repository into your Unity project. Or, if your Unity project is
  already a git repository, add this repository as a submodule.
* Download and install the latest [`.unitypackage` release][releases]

Then, go to `Edit > Project Settings > Player > Other Settings > Configuration`
and change `Api Compatability Level` to ".NET 4.x"


## Usage
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
[discussions/36]: https://github.com/exodrifter/unity-python/discussions/36
