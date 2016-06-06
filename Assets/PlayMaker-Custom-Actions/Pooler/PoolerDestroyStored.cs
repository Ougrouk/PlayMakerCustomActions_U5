/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{   // Gokhan Ergin ERYILDIR (ergin3d)
	[ActionCategory("Pooler")]
	[Tooltip("Disables the stored pooled object for later use.")]
	public class PoolerDestroyStored : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The GameObject to destroy.")]
		public FsmGameObject gameObject;

		public override void Reset()
		{
			gameObject = null;
		}

		public override void OnEnter()
		{
			var go = gameObject.Value;

			if (go != null) {
				go.SetActive (false);
			}

			Finish();
		}


	}

}
