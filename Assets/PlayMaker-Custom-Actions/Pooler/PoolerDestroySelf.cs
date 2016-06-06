/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{   // Gokhan Ergin ERYILDIR (ergin3d)
	[ActionCategory("Pooler")]
	[Tooltip("Disables the pooled pbject so that it can be spawned again when neccesary. ")]
	public class PoolerDestroySelf : FsmStateAction
	{
		public override void OnEnter()
		{

			if (Owner != null) {
				Owner.SetActive (false);
			}

			Finish();
		}
	}
	
}
