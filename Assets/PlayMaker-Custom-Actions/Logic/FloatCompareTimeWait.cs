/*--- __ECO__ __PLAYMAKER__ __ACTION__ ---*/

using UnityEngine;
using System.Collections;

namespace HutongGames.PlayMaker.Actions
{ // Gokhan Ergin ERYILDIR (ergin3d)

	[ActionCategory("Logic")]
	[Tooltip("Compares variables in a coroutine in given intervals and triggers events when requirements are met.")]
	public class FloatCompareTimeWait : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The first float variable.")]
		public FsmFloat float1;

		public enum Compare {isGreaterThan,isLessThan};

		[Tooltip("Condition needed to trigger done event. WHEN float1 is Greater Than float2 DONE")]
		public Compare WaitUntill = Compare.isGreaterThan;

		[RequiredField]
		[Tooltip("The second float variable.")]
		public FsmFloat float2;

		[RequiredField]
		[Tooltip("two variables will be compared every nth time (float)")]
		public FsmFloat IntervalTimeFloat;

		[Tooltip("Event sent if compare condition is met.")]
		public FsmEvent Done;

		public override void Reset()
		{
			float1 = new FsmFloat { UseVariable = true };
			float2 = new FsmFloat { UseVariable = true };
			IntervalTimeFloat = 0.1f;
			WaitUntill = Compare.isGreaterThan;
			Done = null;
		}

		public override void OnEnter()
		{
			StartCoroutine (CompareVariables());
		}
			
		IEnumerator CompareVariables() {

			float timetowait = IntervalTimeFloat.Value;
			float variable1 = float1.Value;
			float variable2 = float2.Value;

			switch (WaitUntill)
			{
			case Compare.isGreaterThan:
				while (variable1 < variable2) {
					variable1 = float1.Value;
					variable2 = float2.Value;
					yield return new WaitForSeconds(timetowait);
				}
				break;

			case Compare.isLessThan:
				while (variable1 > variable2) {
					variable1 = float1.Value;
					variable2 = float2.Value;
					yield return new WaitForSeconds(timetowait);
				}
				break;
			}

			Fsm.Event(Done);
		}
		
	}

}
