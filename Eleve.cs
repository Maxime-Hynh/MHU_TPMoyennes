using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Eleve
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public List<Note> Notes = new List<Note>();

        public Eleve(string nom, string prenom)
        {
            this.nom = nom;
            this.prenom = prenom;
        }

        public void ajouterNote(Note note)
        {
            Notes.Add(note);
        }

        public float moyenneMatiere(int matiereId)
        {
            float moyenne = 0;
            int count = 0;

            foreach (var note in Notes)
            {
              if (note.matiere == matiereId)
                {
                    moyenne += note.note;
                    count++;
                }  
            }

            try {
                return (float)Math.Round((moyenne / count), 2);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
                return 0f;
            }

            
        }

        public float moyenneGeneral()
        {
            float moyenne = 0;
            Dictionary<int, float[]> moyenneParMatiere = new Dictionary<int, float[]>();

            foreach (var note in Notes)
            {
                if (moyenneParMatiere.ContainsKey(note.matiere))
                {
                    moyenneParMatiere[note.matiere][0] += note.note;
                    moyenneParMatiere[note.matiere][1]++;
                } else
                {
                    moyenneParMatiere.Add(note.matiere, new float[] { note.note, 1 });
                }
            }

            foreach (var moyenneMatiere in moyenneParMatiere)
            {
                moyenne += moyenneMatiere.Value[0] / moyenneMatiere.Value[1];
            }
            try
            {
                return (float)Math.Round((moyenne / moyenneParMatiere.Count), 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0f;
            }
           
        }

    }
}
