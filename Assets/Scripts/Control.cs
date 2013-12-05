using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
	
	private bool activo=true;
	public bool stop=false;
	public float timer;
	
	public GUIText txt_freeze;
	public GUIText txt_timer;
	
	private static Control instancia; 
	public static BloqueScript bloqueActivo; 

	public GameObject[] lineas;
	
	private void Awake(){
		instancia = this;	
		lineas = new GameObject[10];
		for(int i=0; i<10;i++){
			lineas[i] = new GameObject("Linea"+i);
		}
	}
	
	// Use this for initialization
	void Start() {
		txt_freeze.guiText.text = "";
		crearFigura();
		bloqueActivo = null;
	}
	
	// Update is called once per frame
	void Update() {
		
		if(timer>=0){
			timer -= Time.deltaTime;
			txt_timer.guiText.text = timer.ToString("F1");
		} 
	}
	
	public static Control getInstancia{
		get{
			return instancia;	
		}
	}

	public static BloqueScript getBloque{
		get{
			return bloqueActivo;	
		}
	}

	
	public bool estaActivo{
		get{
			return activo;	
		}
		set{
			activo=value;	
		}
	}
	
	public void crearFigura(){
		
		Vector3 posInicio = new Vector3(0.25f,6.75f,0);
		
		int rand_fig = UnityEngine.Random.Range (1,6);
		
		Debug.Log("Prefabs/Figura"+ rand_fig);
		Instantiate(Resources.Load("Prefabs/Figura"+ rand_fig), posInicio, transform.rotation);
		Instantiate(Resources.Load("Prefabs/CuadF"+ rand_fig), posInicio, transform.rotation);
	}

	public void deseleccionarBloque(){
		bloqueActivo.transform.localScale -= new Vector3(0.2f,0.2f,0);
		bloqueActivo = null;
	}

	public void eliminarCuad(){
		GameObject basurero = new GameObject();
		GameObject[] array;
		array = GameObject.FindGameObjectsWithTag("BCuad");
		
		foreach (GameObject basura in array){
			basura.transform.parent = basurero.transform;
		}
		GameObject.Destroy(basurero);
	}
}

