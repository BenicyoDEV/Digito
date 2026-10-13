using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProgramavel
{
	void RestaurarRegiao();
	
	void RestaurarArvores();
	void DesativarInfestacaoCogumelo();
	void EmergirIlhaMet1();
	void EmergirIlhaMet2();
	void EmergirIlhaMet3();
	void CurarInimigos();
	void MudarCogumelos(int quantidade);
}
