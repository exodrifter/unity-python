using UnityEngine;
using IronPython.Hosting;

namespace Exodrifter.UnityPython.Examples
{
	public class PythonHelloWorld : MonoBehaviour
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
}