using MoreMountains.Tools;
using UnityEngine;

public class Test : MonoBehaviour
{
	public string OutputValue = "110";
	[MMInspectorButton("TestSpawn")]
	public bool TestButton;
    
	public void TestSpawn()
	{
		MMFloatingTextSpawnEvent.Trigger(0, this.transform.position, 
			OutputValue, Vector3.up, 1f);
	}
}
