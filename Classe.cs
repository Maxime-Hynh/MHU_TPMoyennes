using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HNI_TPmoyennes
{
    class Classe
    {
        public List<Eleve> eleves = new List<Eleve>();
        public List<string> matieres = new List<string>();
        public string nomClasse;
        public Classe(string nom)
        {
            nomClasse = nom;
        }

        public void ajouterEleve(string nom, string prenom)
        {
            var eleve = new Eleve(nom, prenom);
            eleves.Add(eleve);
        }

        public void ajouterMatiere(string nomMatiere)
        {
            matieres.Add(nomMatiere);
        }

        public float moyenneMatiere(int matiereId)
        {
            float somme = 0;
            foreach (var eleve in eleves)
            {
                somme += eleve.moyenneMatiere(matiereId);
            }
            try
            {
                return (float) Math.Round(somme / eleves.Count, 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return 0f;

            }
        }

        public float moyenneGeneral()
        {
            float somme = 0;
            foreach (var eleve in eleves)
            {
                somme += eleve.moyenneGeneral();
            }
            try
            {
                return (float)Math.Round(somme / eleves.Count, 2);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
                return 0f;
            }
            
        }
    }
}
