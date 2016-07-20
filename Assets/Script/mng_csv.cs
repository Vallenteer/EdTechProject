using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class mng_csv : MonoBehaviour {

	//TODO : Masukin fungsi addData ke behavior soal mng

	[SerializeField] string namaFile = "Saved_data.csv";  
	[SerializeField] string delimiter = ",";  
	List<string[]> rowData = new List<string[]>();
	string[] rowDataTemp = new string[3];

	void Start(){
		AddData ("Soal", "Jawaban Benar", "Jawaban");
	}

	void Update(){
		/*
		if (Input.GetKeyUp (KeyCode.Space)) {
			Savecsv ();
		}
		*/
	}

	public void AddData(string soal, string jawabanBenar, string jawabanYangdijawab){
		rowDataTemp [0] = soal;
		rowDataTemp [1] = jawabanBenar;
		rowDataTemp [2] = jawabanYangdijawab;
		rowData.Add (rowDataTemp);
	}

	void Savecsv() { 
		string filePath = getPath ();
		string[][] output = new string[rowData.Count][]; 
	
		for(int i = 0; i < output.Length; i++){
			output[i] = rowData[i];
		}
			
		int length = output.GetLength(0);  
		StringBuilder sb = new StringBuilder();  
		for (int index = 0; index < length; index++)  
			sb.AppendLine(string.Join(delimiter, output[index]));  

		StreamWriter outStream = System.IO.File.CreateText(filePath);
		outStream.WriteLine(sb);
		outStream.Close();
		//File.WriteAllText (filePath, sb.ToString ());
	}

	string getPath(){
		#if UNITY_EDITOR
		return Application.dataPath +namaFile;
		#elif UNITY_ANDROID
		return Application.persistentDataPath+namaFile;
		#elif UNITY_IPHONE
		return Application.persistentDataPath+"/"+namaFile;
		#else
		return Application.dataPath +"/"+namaFile;
		#endif
	}
}
