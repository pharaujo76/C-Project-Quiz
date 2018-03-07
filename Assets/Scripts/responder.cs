using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class responder : MonoBehaviour {

	private int idTema;

	public Text pergunta;
	public Text respostaA;
	public Text respostaB;
	public Text respostaC;
	public Text respostaD;
	public Text InfoResposta;

	public string[] perguntas;
	public string[] alternativaA;
	public string[] alternativaB;
	public string[] alternativaC;
	public string[] alternativaD;
	public string[] corretas;

	private int idPergunta;

	private float acerto;
	private float questoes;
	private float media;
	private int	  notaFinal;
	// Use this for initialization
	void Start () {
		idPergunta = 0;
		questoes = perguntas.Length;

		pergunta.text = perguntas [idPergunta];
		respostaA.text = alternativaA [idPergunta];
		respostaB.text = alternativaB [idPergunta];
		respostaC.text = alternativaC [idPergunta];
		respostaD.text = alternativaD [idPergunta];

		InfoResposta.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString () + " perguntas.";
	}
	
	public void resposta(string alternativa){

		if (alternativa == "A") {
		
			if(alternativaA[idPergunta] == corretas[idPergunta]){

				acerto += 1;
			}
		}

		else if (alternativa == "B") {
			
			if(alternativaB[idPergunta] == corretas[idPergunta]){
				
				acerto += 1;
			}
		}

		else if (alternativa == "C") {
			
			if(alternativaC[idPergunta] == corretas[idPergunta]){
				
				acerto += 1;
			}
		}

		else if (alternativa == "D") {
			
			if(alternativaD[idPergunta] == corretas[idPergunta]){
				
				acerto += 1;
			}
		}

		proximaPergunta ();
	}

	void proximaPergunta(){

		idTema = PlayerPrefs.GetInt("idTema");
		idPergunta += 1;

		if (idPergunta <= (questoes - 1)) {
		

			pergunta.text = perguntas [idPergunta];
			respostaA.text = alternativaA [idPergunta];
			respostaB.text = alternativaB [idPergunta];
			respostaC.text = alternativaC [idPergunta];
			respostaD.text = alternativaD [idPergunta];
		
			InfoResposta.text = "Respondendo " + (idPergunta + 1) + " de " + questoes.ToString () + " perguntas.";
	
		} else {
		
			media = 10 * (acerto / questoes);
			notaFinal = Mathf.RoundToInt(media);

			if(notaFinal > PlayerPrefs.GetInt("notaFinal"+idTema.ToString())){

				PlayerPrefs.SetInt("notaFinal"+idTema.ToString(),notaFinal);
				PlayerPrefs.SetInt("acertos"+idTema.ToString(),(int)acerto);
			}

			PlayerPrefs.SetInt("notaFinalTemp"+idTema.ToString(),notaFinal);
			PlayerPrefs.SetInt("acertosTemp"+idTema.ToString(),(int)acerto);

			Application.LoadLevel("notaFinal");
		
		}

	}

}
