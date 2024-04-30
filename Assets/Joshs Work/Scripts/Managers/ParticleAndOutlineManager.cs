using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Displays Particles and Outlines when a particular Lens is activated
public class ParticleAndOutlineManager : MonoBehaviour {
	[Header("Lens Particle Lists:")]
	public List<GameObject> revealParticlesList;
    public List<GameObject> reverseParticlesList;
	public List<GameObject> realityParticlesList;
	[Space(5)]
	[Header("Outline Lists:")]
	public List<Outline> revealOutlinesList;
	public List<Outline> reverseOutlinesList;
	public List<Outline> realityOutlinesList;
	
	public void DisplayRevealParticles() {
		if (revealParticlesList != null) {
			foreach (GameObject revealParticle in revealParticlesList) {
				revealParticle.SetActive(true);
			}
		}
	}
	public void DisplayRevealOutlines() {
		if (revealOutlinesList != null) {
			foreach (Outline revealOutline in revealOutlinesList) {
				revealOutline.enabled = true;
			}
		}
	}

	public void DisplayRealityParticles() {
		if (realityParticlesList != null) {
			foreach (GameObject realityParticle in realityParticlesList) {
				realityParticle.SetActive(true);
			}
		}
	}
	public void DisplayRealityOutlines() {
		if (realityOutlinesList != null) {
			foreach (Outline realityOutline in realityOutlinesList) {
				realityOutline.enabled = true;
			}
		}
	}

	public void DisplayReverseParticles() {
		if (reverseParticlesList != null) {
			foreach (GameObject reverseParticle in reverseParticlesList) {
				reverseParticle.SetActive(true);
			}
		}
	}
	public void DisplayReverseOutlines() {
		if (reverseOutlinesList != null) {
			foreach (Outline reverseOutline in reverseOutlinesList) {
				reverseOutline.enabled = true;
			}
		}
	}

	public void HideRevealParticles() {
		if (revealParticlesList != null) {
			foreach (GameObject revealParticle in revealParticlesList) {
				revealParticle.SetActive(false);
			}
		}
	}
	public void HideRevealOutlines() {
		if (revealOutlinesList != null) {
			foreach (Outline revealOutline in revealOutlinesList) {
				revealOutline.enabled = false;
			}
		}
	}

	public void HideRealityParticles() {
		if (realityParticlesList != null) {
			foreach (GameObject realityParticle in realityParticlesList) {
				realityParticle.SetActive(false);
			}
		}
	}
	public void HideRealityOutlines() {
		if (realityOutlinesList != null) {
			foreach (Outline realityOutline in realityOutlinesList) {
				realityOutline.enabled = false;
			}
		}
	}

	public void HideReverseParticles() {
		if (reverseParticlesList != null) {
			foreach (GameObject reverseParticle in reverseParticlesList) {
				reverseParticle.SetActive(false);
			}
		}
	}
	public void HideReverseOutlines() {
		if (reverseOutlinesList != null) {
			foreach (Outline reverseOutline in reverseOutlinesList) {
				reverseOutline.enabled = false;
			}
		}
	}
}