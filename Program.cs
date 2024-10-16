﻿using System.Data.Entity;

class Program
{
    public static void Main()
    {
        string path = @"C:\Users\pozza\Documents\VisualStudioCode\Prima-lezione\";
        Model db = new Model();
        View view = new View(db);
        Controller controller = new Controller(db, view);

      
            if (!db.Partecipanti.ToList().Any())
            {
                //Inizializzazione DB da files nomi
                //Inserisce i partecipanti nel db da file
                List<string> partecipanti = new List<string>(File.ReadAllLines($"{path}Partecipanti.txt")); //Legge il file nomi e li inseriesce in una List
                foreach (var partecipante in partecipanti)
                    controller.AddNome(partecipante);
                db.SaveChanges();
            }
            if (!db.Professionisti.ToList().Any())
            {
                //Inserisce i professionisti nel db da csv
                var reader = new StreamReader(File.OpenRead($"{path}Professionisti.csv"));
                List<Professionista> pro = new List<Professionista>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line!.Split(',');
                    pro.Add(new Professionista(values[0], Convert.ToInt32(values[1])));
                }
                foreach (var element in pro)
                    controller.RendiPro(element.Nome, element.Score);
                db.SaveChanges();
                reader.Close();
            }
        

        controller.Menu();
    }
}