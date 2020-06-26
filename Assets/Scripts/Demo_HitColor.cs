using System.Collections;
using CRI.HitBoxTemplate.Serial;
using UnityEngine;

namespace CRI.HitBoxTemplate.Example
{
	public class Demo_HitColor : MonoBehaviour
	{
		[SerializeField]
		private Color _color1 = Color.blue;
		[SerializeField]
		private Color _color2 = Color.red;

		private void OnEnable()
		{
			ImpactPointControl.onImpact += OnImpact;
		}

		private void OnDisable()
		{ 
			ImpactPointControl.onImpact -= OnImpact;
		}

		private void OnImpact(object sender, ImpactPointControlEventArgs e)
		{
			float range_ = this.gameObject.transform.localScale.x;
			if(e.impactPosition.x > this.gameObject.transform.position.x - range_ / 2f && e.impactPosition.x < this.gameObject.transform.position.x + range_ / 2f)
			{
				StartCoroutine(HitColor());
			}
		}

		private void Start()
		{
			var renderer_ = this.gameObject.GetComponent<Renderer>();
			renderer_.material.SetColor("_Color", _color1);
		}

		private IEnumerator HitColor()
		{
			var renderer_ = this.gameObject.GetComponent<Renderer>();
			renderer_.material.SetColor("_Color", _color2);
			yield return new WaitForSeconds(0.3f);
			renderer_.material.SetColor("_Color", _color1);
		}
	}
}
