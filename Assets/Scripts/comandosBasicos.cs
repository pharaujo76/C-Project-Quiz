using UnityEngine;
using System.Collections;

public class Comandos : MonoBehaviour {

	public void carregarCena(string nomeCena){

		Application.LoadLevel (nomeCena);
	}


	public void resetarontuacoes(){

		PlayerPrefs.DeleteAll ();
	}
}
