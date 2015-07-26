using UnityEngine;

using System.Collections;

using LunarPlugin;

[CVarContainer]
static class Cvars
{
	public static readonly CVar godMode = new CVar("godMode", false);

	static Cvars()
	{
		godMode.AddDelegate(delegate(CVar cvar) {

			if (Application.isPlaying)
			{
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				Material[] materials = player.GetComponent<MeshRenderer>().materials;
				
				Color color = cvar.BoolValue ? Color.red : Color.white;
				foreach (Material m in materials)
				{
					m.color = color;
				}
			}

		});
	}
}
